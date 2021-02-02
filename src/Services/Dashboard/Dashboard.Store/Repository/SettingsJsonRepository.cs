using System.Linq;
using System.Threading.Tasks;
using Dashboard.Helpers;
using Dashboard.Store.Context;
using Dashboard.Store.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Store.Repository
{
    public class SettingsJsonRepository : ISettingsRepository
    {
        public SettingsJsonRepository(SettingsContext ctx, ICacheService mem)
        {
            Db = ctx;
            _cache = mem;
        }

        private SettingsContext Db { get; }
        private readonly ICacheService _cache;

        public GlobalSettings Insert(GlobalSettings entity)
        {
            using (var tran = Db.Database.BeginTransaction())
            {
                var settings = Db.Settings.Add(entity);
                Db.SaveChanges();
                tran.Commit();
                return settings.Entity;
            }
        }

        public async Task<GlobalSettings> InsertAsync(GlobalSettings entity)
        {
            using (var tran = Db.Database.BeginTransaction())
            {
                var settings = await Db.Settings.AddAsync(entity);
                await Db.SaveChangesAsync();
                tran.Commit();

                return settings.Entity;
            }
        }

        public GlobalSettings Get(string pageName)
        {
            var entity = Db.Settings.AsNoTracking().FirstOrDefault(x => x.SettingsName == pageName);
            return entity;
        }

        public async Task<GlobalSettings> GetAsync(string settingsName)
        {
            var obj = await Db.Settings.AsNoTracking().FirstOrDefaultAsync(x => x.SettingsName == settingsName);
            return obj;
        }

        public async Task DeleteAsync(GlobalSettings entity)
        {
            Db.Settings.Remove(entity);
            await InternalSaveChanges();
        }

        public async Task UpdateAsync(GlobalSettings entity)
        {
            Db.Update(entity);
            await InternalSaveChanges();
        }

        public void Delete(GlobalSettings entity)
        {
            using (var tran = Db.Database.BeginTransaction())
            {
                Db.Settings.Remove(entity);
                Db.SaveChanges();
                tran.Commit();
            }
        }

        public void Update(GlobalSettings entity)
        {
            using (var tran = Db.Database.BeginTransaction())
            {
                Db.Update(entity);
                Db.SaveChanges();
                tran.Commit();
            }
        }

        private string GetName(string entity)
        {
            return $"{entity}Json";
        }

        private async Task<int> InternalSaveChanges()
        {

            using (var tran = Db.Database.BeginTransaction())
            {
                var r = await Db.SaveChangesAsync();
                tran.Commit();
                return r;
            }
        }
    }
}