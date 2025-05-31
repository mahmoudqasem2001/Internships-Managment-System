
using Microsoft.AspNetCore.Identity;
using InternGo.Domain.Entities;
using InternGo.Domain.Interfaces.Persistence.Repositories;
using InternGo.Infrastructure.Authentication.Jwt;
using InternGo.Domain.Enums;
using InternGo.Application.Authentication;
using InternGo.Application.Authentication.Common;

namespace InternGo.Infrastructure.Authentication
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AuthService(
            IUserRepository userRepository,
            IJwtTokenGenerator jwtTokenGenerator,
            IPasswordHasher<User> passwordHasher)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
            _passwordHasher = passwordHasher;
        }

        public async Task<AuthenticationResult> LoginAsync(LoginRequest request)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);

            if (user == null)
            {
                throw new Exception("Invalid credentials");
            }

            var verifyResult = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, request.Password);
            if (verifyResult == PasswordVerificationResult.Failed)
            {
                throw new Exception("Invalid credentials");
            }

            var token = _jwtTokenGenerator.GenerateToken(user.Id, user.Email, user.Role.ToString());

            return new AuthenticationResult
            {
                Token = token,
                Email = user.Email,
                Role = user.Role.ToString()
            };
        }

        public async Task<AuthenticationResult> RegisterAsync(RegisterRequest request)
        {
            var existingUser = await _userRepository.GetByEmailAsync(request.Email);
            if (existingUser != null)
                throw new Exception("Email is already registered");

            var user = new User
            {
                Id = Guid.NewGuid(),
                FullName = request.FullName,
                Email = request.Email,
                Role = Enum.Parse<UserRole>(request.Role, true),
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            user.PasswordHash = _passwordHasher.HashPassword(user, request.Password);

            await _userRepository.AddAsync(user);

            var token = _jwtTokenGenerator.GenerateToken(user.Id, user.Email, user.Role.ToString());

            return new AuthenticationResult
            {
                Token = token,
                Email = user.Email,
                Role = user.Role.ToString()
            };
        }


    }
}
