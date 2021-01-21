using System.Linq;
using System.Runtime.InteropServices;
using Dashboard.Store.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Store.Context
{
    public abstract class SettingsContext : DbContext
    {
        protected SettingsContext(DbContextOptions<SettingsContext> options) : base(options)
        {
        }

        protected SettingsContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<GlobalSettings> Settings { get; set; }
        public DbSet<ApplicationConfiguration> ApplicationConfigurations { get; set; }

        public void Sees()
        {
            using (var tran = Database.BeginTransaction())
            {
                var fanArt = ApplicationConfigurations.FirstOrDefault(x => x.Type == ConfigurationTypes.FanartTv);
                if (fanArt == null)
                {
                    ApplicationConfigurations.Add(new ApplicationConfiguration
                    {
                        Type = ConfigurationTypes.FanartTv,
                        Value = "45ce887d2bd0d1fbc25ffe513b8b64de"
                    });
                    SaveChanges();
                }

                var movieDb = ApplicationConfigurations.FirstOrDefault(x => x.Type == ConfigurationTypes.TheMovieDb);
                if (movieDb == null)
                {
                    ApplicationConfigurations.Add(new ApplicationConfiguration
                    {
                        Type = ConfigurationTypes.TheMovieDb,
                        Value = "8e8b06b1cb21b2d3f36f8bd44c933672"
                    });
                    SaveChanges();
                }

                var notification =
                    ApplicationConfigurations.FirstOrDefault(x => x.Type == ConfigurationTypes.Notification);
                if (notification == null)
                {
                    ApplicationConfigurations.Add(new ApplicationConfiguration
                    {
                        Type = ConfigurationTypes.Notification,
                        Value = ""
                    });
                    SaveChanges();
                }
                tran.Commit();
            }
        }
    }
}