using InternGo.Application.Students.Common;

public interface IStudentService
{
    Task UpdateStudentProfileAsync(Guid studentUserId, UpdateStudentProfileRequest request);
    Task<StudentProfileDto?> GetStudentProfileAsync(Guid studentUserId);
    Task CreateStudentProfileAsync(Guid studentUserId, CreateStudentProfileRequest request);

}
