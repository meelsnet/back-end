namespace Dashboard.Settings.Settings
{
    public interface ISettingsResolver
    {
        ISettingsService<T> Resolve<T>();
    }
}