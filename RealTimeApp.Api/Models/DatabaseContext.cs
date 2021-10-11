using Microsoft.EntityFrameworkCore;

namespace RealTimeApp.Api.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DbSet<BackendFramework> BackendFrameworks { get; set; }
        public DbSet<SurveyItem> SurveyItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BackendFramework>().HasData(

                    new BackendFramework { Id = 1, Name = ".Net Core" },
                    new BackendFramework { Id = 2, Name = "Spring Boot" },
                    new BackendFramework { Id = 3, Name = "Ruby" },
                    new BackendFramework { Id = 4, Name = "Laravel" },
                    new BackendFramework { Id = 5, Name = "ExpressJs" },
                    new BackendFramework { Id = 6, Name = "Django" },
                    new BackendFramework { Id = 7, Name = "Koa" },
                    new BackendFramework { Id = 8, Name = "Flask" },
                    new BackendFramework { Id = 9, Name = "Symfony" },
                    new BackendFramework { Id = 10, Name = "Phoenix" }
                );
        }
    }
}