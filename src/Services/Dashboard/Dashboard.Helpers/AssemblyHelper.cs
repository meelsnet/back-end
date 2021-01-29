using Microsoft.Extensions.PlatformAbstractions;

namespace Dashboard.Helpers
{
    public static class AssemblyHelper
    {
        public static string GetRuntimeVersion()
        {
            ApplicationEnvironment app = PlatformServices.Default.Application;
            return app.ApplicationVersion;
        }
    }
}