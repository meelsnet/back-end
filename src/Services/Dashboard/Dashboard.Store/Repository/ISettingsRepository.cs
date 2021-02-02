using System.Threading.Tasks;
using Dashboard.Store.Entities;

namespace Dashboard.Store.Repository
{
    public interface ISettingsRepository
    {
        GlobalSettings Insert(GlobalSettings entity);
        Task<GlobalSettings> InsertAsync(GlobalSettings entity);
        GlobalSettings Get(string settingsName);
        Task<GlobalSettings> GetAsync(string settingsName);
        Task DeleteAsync(GlobalSettings entity);
        void Delete(GlobalSettings entity);
        Task UpdateAsync(GlobalSettings entity);
        void Update(GlobalSettings entity);
    }
}