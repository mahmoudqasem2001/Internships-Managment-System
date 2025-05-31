using InternGo.Application.Admin;
using InternGo.Application.Admin.Common;
using InternGo.Application.AI;
using InternGo.Application.Applications;
using InternGo.Application.Applications.Common;
using InternGo.Application.Authentication;
using InternGo.Application.Companies.Common;
using InternGo.Application.Internships.Common;
using InternGo.Application.Reviews;
using InternGo.Domain.Entities;
using InternGo.Domain.Interfaces.Persistence;
using InternGo.Domain.Interfaces.Persistence.Repositories;
using InternGo.Infrastructure.Admin;
using InternGo.Infrastructure.AI;
using InternGo.Infrastructure.Applications;
using InternGo.Infrastructure.Authentication;
using InternGo.Infrastructure.Companies;
using InternGo.Infrastructure.Internships;
using InternGo.Infrastructure.Persistence.DbContexts;
using InternGo.Infrastructure.Persistence.Repositories;
using InternGo.Infrastructure.Reviews;
using InternGo.Infrastructure.Students;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace InternGo.Infrastructure.Persistence;

public static class PersistenceConfiguration
{
    internal static IServiceCollection AddPersistenceInfrastructure(
      this IServiceCollection services,
      IConfiguration configuration)
    {
        services.AddDbContext(configuration)
          .AddPasswordHashing().AddRepositories();
         

        return services;
    }

    private static IServiceCollection AddDbContext(
      this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<InternGoDbContext>(options =>
        {

            options.UseSqlServer(
             configuration.GetConnectionString("SqlServer"),
             sqlOptions => sqlOptions.MigrationsAssembly(typeof(InternGoDbContext).Assembly.FullName)
         );

        });

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }

    private static IServiceCollection AddPasswordHashing(this IServiceCollection services)
    {
        services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {

        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IInternshipRepository, InternshipRepository>();
        services.AddScoped<ICompanyProfileRepository, CompanyProfileRepository>();
        services.AddScoped<ICompanyApplicationService, CompanyApplicationService>();
        services.AddScoped<IApplicationService, ApplicationService>();
        services.AddScoped<IInternshipService, InternshipService>();
        services.AddScoped<ICompanyService, CompanyService>();
        services.AddScoped<IReviewService, ReviewService>();
        services.AddScoped<IStudentService, StudentService>();
        services.AddScoped<IStudentProfileRepository, StudentProfileRepository>();
        services.AddScoped<IAIRecommendationService, AIRecommendationService>();
        services.AddScoped<IAdminService, AdminService>();

        return services;
    }

}