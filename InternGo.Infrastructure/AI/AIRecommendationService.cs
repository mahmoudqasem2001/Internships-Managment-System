using InternGo.Application.AI;
using InternGo.Application.AI.Common;
using InternGo.Domain.Entities;
using InternGo.Domain.Interfaces.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace InternGo.Infrastructure.AI
{
    public class AIRecommendationService : IAIRecommendationService
    {
        private readonly IUnitOfWork _unitOfWork;

        private static readonly Dictionary<string, string> SkillSynonyms = new()
        {
            { ".net", "dotnet" },
            { "aspnet", "dotnet" },
            { "c#", "csharp" },
            { "js", "javascript" },
            { "sqlserver", "sql" },
            { "postgresql", "sql" },
            { "nodejs", "node" },
            { "python3", "python" },
            { "ai", "machinelearning" }
        };

        private static readonly Dictionary<string, double> SkillWeights = new()
        {
            { "dotnet", 1.5 },
            { "csharp", 1.3 },
            { "javascript", 1.2 },
            { "python", 1.1 },
            { "sql", 1.2 },
            { "html", 0.8 },
            { "css", 0.8 },
            { "teamwork", 0.5 },
            { "communication", 0.5 }
        };

        public AIRecommendationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<RecommendedInternshipDto>> RecommendInternshipsAsync(Guid studentUserId)
        {
            var student = await _unitOfWork.StudentProfiles
                .GetQueryable()
                .Include(sp => sp.User)
                .FirstOrDefaultAsync(sp => sp.UserId == studentUserId);

            if (student == null)
                throw new Exception("Student profile not found.");

            var combinedText = string.Join(" ",
                student.Skills ?? "",
                student.ProgrammingLanguages ?? "",
                student.Experience ?? "",
                student.CoverLetter ?? ""
            );

            var studentSkills = ExtractKeywords(combinedText);
            var preferredLocation = student.PreferredLocation?.ToLower().Trim();

            var internships = await _unitOfWork.Internships
                .GetQueryable()
                .Include(i => i.CompanyProfile)
                .ToListAsync();

            var recommendations = new List<RecommendedInternshipDto>();

            foreach (var internship in internships)
            {
                var requiredSkills = ExtractKeywords(internship.SkillsRequired);
                var matchScore = ComputeMatchScore(studentSkills, requiredSkills);

                const double locationMatchBonus = 0.2;

                if (!string.IsNullOrEmpty(preferredLocation) &&
                    internship.CompanyProfile.Location.ToLower().Contains(preferredLocation))
                {
                    matchScore += locationMatchBonus;
                }

                if (matchScore > 0)
                {
                    var aiEntry = new AIRecommendation
                    {
                        Id = Guid.NewGuid(),
                        StudentProfileId = student.Id,
                        InternshipId = internship.Id,
                        MatchScore = matchScore,
                        RecommendedAt = DateTime.UtcNow
                    };

                    await _unitOfWork.AIRecommendations.AddAsync(aiEntry);

                    recommendations.Add(new RecommendedInternshipDto
                    {
                        InternshipId = internship.Id,
                        Title = internship.Title,
                        Description = internship.Description,
                        CompanyName = internship.CompanyProfile.CompanyName,
                        MatchScore = Math.Round(matchScore, 2)
                    });
                }
            }

            await _unitOfWork.SaveChangesAsync();
            return recommendations.OrderByDescending(r => r.MatchScore).ToList();
        }

        private List<string> ExtractKeywords(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return new List<string>();

            var words = Regex.Matches(text.ToLower(), @"\b[a-z#0-9+]+\b")
                             .Select(m => m.Value)
                             .ToList();

            var normalized = words
                .Select(w => SkillSynonyms.TryGetValue(w, out var norm) ? norm : w)
                .Distinct()
                .ToList();

            return normalized;
        }

        private double ComputeMatchScore(List<string> studentSkills, List<string> requiredSkills)
        {
            if (requiredSkills.Count == 0) return 0;

            double totalScore = 0;
            double maxPossible = 0;

            foreach (var skill in requiredSkills)
            {
                var weight = SkillWeights.TryGetValue(skill, out var w) ? w : 1.0;
                maxPossible += weight;

                if (studentSkills.Contains(skill))
                    totalScore += weight;
            }

            return totalScore / maxPossible;
        }
    }
}
