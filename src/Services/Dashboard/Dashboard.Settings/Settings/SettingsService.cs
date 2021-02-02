using System.Threading.Tasks;
using Dashboard.Helpers;
using Dashboard.Store.Repository;

namespace Dashboard.Settings.Settings
{
    public class SettingsService<T> : ISettingsService<T>
        where T : Models.Settings, new()
    {
        public SettingsService(ISettingsRepository repo, ICacheService cache)
        {
            Repo = repo;
            EntityName = typeof(T).Name;
            _cache = cache;
        }

        private ISettingsRepository Repo { get; }
        private string EntityName { get; }
        private string CacheName => $"Settings{EntityName}";
        private readonly ICacheService _cache;

        public T GetSettings()
        {
            throw new System.NotImplementedException();
        }

        public Task<T> GetSettingsAsync()
        {
            throw new System.NotImplementedException();
        }

        public bool SaveSettings(T model)
        {
            throw new System.NotImplementedException();
        }

        public Task<T> SaveSettingsAsync()
        {
            throw new System.NotImplementedException();
        }

        public void Delete(T model)
        {
            throw new System.NotImplementedException();
        }

        public Task<T> DeleteAsync()
        {
            throw new System.NotImplementedException();
        }

        public void ClearCache()
        {
            throw new System.NotImplementedException();
        }
    };
}