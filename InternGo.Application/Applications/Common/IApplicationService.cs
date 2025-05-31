namespace InternGo.Application.Applications.Common
{
    public interface IApplicationService
    {
        Task<Guid> ApplyAsync(Guid studentUserId, ApplyRequest request);
        Task<List<ApplicationDto>> GetMyApplicationsAsync(Guid studentUserId);
        Task<string> GetApplicationStatusAsync(Guid studentUserId, Guid applicationId);

    }
}
