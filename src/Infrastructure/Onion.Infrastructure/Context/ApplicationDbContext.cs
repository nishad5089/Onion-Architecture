using System.IO;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Onion.Domain.Models;
using Onion.Repository.Interfaces;

namespace Onion.Infrastructure.Context {
    public class ApplicationDbContext : DbContext, IApplicationDbContext {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base (options) { }
        public DbSet<Student> Students { get; set; }

        public Task<int> SaveChangesAsync () {
            return base.SaveChangesAsync ();
        }

        public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext> {
            public ApplicationDbContext CreateDbContext (string[] args) {
                IConfigurationRoot configuration = new ConfigurationBuilder ()
                    .SetBasePath (Directory.GetCurrentDirectory ())
                    .AddJsonFile (@Directory.GetCurrentDirectory () + "../../../UI/Onion.API/appsettings.json")
                    .Build ();
                var builder = new DbContextOptionsBuilder<ApplicationDbContext> ();
                var connectionString = configuration.GetConnectionString ("OnionDBConnection");
                builder.UseSqlServer (connectionString);
                return new ApplicationDbContext (builder.Options);
            }
        }
    }
}