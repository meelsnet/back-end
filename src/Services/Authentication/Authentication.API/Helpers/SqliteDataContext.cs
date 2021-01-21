using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Authentication.API.Helpers
{
    public class SqliteDataContext : DataContext
    {
        public SqliteDataContext(IConfiguration configuration)
            : base(configuration) {}

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(configuration.GetConnectionString("DashboardApiDatabase"));
        }
    }
}