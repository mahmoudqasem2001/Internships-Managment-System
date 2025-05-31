using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace InternGo.Infrastructure.Persistence.DbContexts
{
    public class InternGoDbContextFactory : IDesignTimeDbContextFactory<InternGoDbContext>
    {
        public InternGoDbContext CreateDbContext(string[] args)
        {
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "InternGo");

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<InternGoDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("SqlServer"));

            return new InternGoDbContext(optionsBuilder.Options);
        }

    }
}
