namespace InternGo.Application.Students.Common
{
    public class StudentProfileDto
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Experience { get; set; }
        public string Skills { get; set; }
        public string ProgrammingLanguages { get; set; }
        public string CoverLetter { get; set; }
        public string? PreferredLocation { get; set; }
        public string? Phone { get; set; }
    }
}
