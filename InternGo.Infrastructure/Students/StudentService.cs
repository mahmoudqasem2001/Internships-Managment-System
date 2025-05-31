using InternGo.Application.Students;
using InternGo.Application.Students.Common;
using InternGo.Domain.Entities;
using InternGo.Domain.Interfaces.Persistence;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace InternGo.Infrastructure.Students
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task UpdateStudentProfileAsync(Guid studentUserId, UpdateStudentProfileRequest request)
        {
            var studentProfile = await _unitOfWork.StudentProfiles
                .FirstOrDefaultAsync(sp => sp.UserId == studentUserId);

            if (studentProfile == null)
                throw new Exception("Student profile not found.");

            studentProfile.Experience = request.Experience;
            studentProfile.Skills = request.Skills;
            studentProfile.ProgrammingLanguages = request.ProgrammingLanguages;
            studentProfile.CoverLetter = request.CoverLetter;
            studentProfile.PreferredLocation = request.PreferredLocation;
            studentProfile.Phone = request.Phone;

            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<StudentProfileDto?> GetStudentProfileAsync(Guid studentUserId)
        {
            var profile = await _unitOfWork.StudentProfiles
                .GetQueryable()
                .Include(sp => sp.User)
                .FirstOrDefaultAsync(sp => sp.UserId == studentUserId);

            if (profile == null)
                return null;

            return new StudentProfileDto
            {
                FullName = profile.User.FullName,
                Email = profile.User.Email,
                CoverLetter=profile.CoverLetter,
                Experience=profile.Experience,
                Skills=profile.Skills,
                ProgrammingLanguages=profile.ProgrammingLanguages,
                PreferredLocation = profile.PreferredLocation,
                Phone = profile.Phone
            };
        }
        public async Task CreateStudentProfileAsync(Guid studentUserId, CreateStudentProfileRequest request)
        {
            var exists = await _unitOfWork.StudentProfiles
                .GetQueryable()
                .AnyAsync(sp => sp.UserId == studentUserId);

            if (exists)
                throw new Exception("Profile already exists.");

            var profile = new StudentProfile
            {
                Id = Guid.NewGuid(),
                UserId = studentUserId,
                Experience = request.Experience ?? " None ",
                Skills = request.Skills ?? " None ",
                ProgrammingLanguages = request.ProgrammingLanguages ?? " None",
                CoverLetter = request.CoverLetter ?? " None ",
                PreferredLocation = request.PreferredLocation,
                Phone = request.Phone
            };

            await _unitOfWork.StudentProfiles.AddAsync(profile);
            await _unitOfWork.SaveChangesAsync();
        }


    }
}
