using System.Threading.Tasks;

namespace Dashboard.Settings.Settings
{
    public interface ISettingsService<T>
    {
        T GetSettings();
        Task<T> GetSettingsAsync();
        bool SaveSettings(T model);
        Task<T> SaveSettingsAsync();
        void Delete(T model);
        Task<T> DeleteAsync();
        void ClearCache();
    }
}