namespace InternGo.Infrastructure.Authentication.Jwt
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(Guid userId, string email, string role);
    }
}
