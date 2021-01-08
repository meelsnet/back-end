using Authentication.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Authentication.API.Helpers
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration configuration;

        public DataContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(configuration.GetConnectionString("DashboardApiDatabase"));
        }

        public DbSet<User> Users { get; set; }
    }
}