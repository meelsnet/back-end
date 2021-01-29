using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Security.Principal;
using System.Text;
using Dashboard.Api.Core;
using Dashboard.Api.TheMovieDb;
using Dashboard.Helpers;
using Dashboard.Settings.Settings;
using Dashboard.Store.Repository;
using Microsoft.Extensions.DependencyInjection;
using Quartz.Spi;

namespace Dashboard.DependencyInjection
{
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public static class IocExtensions
    {
        public static void RegisterApplicationDependencies(this IServiceCollection services)
        {
            services.RegisterEngines();
            services.RegisterEnginesV2();
            services.RegisterApi();
            services.RegisterServices();
            services.RegisterStore();
            services.RegisterJobs();
            services.RegisterHttp();
        }
        public static void RegisterEngines(this IServiceCollection services)
        {
        }

        public static void RegisterEnginesV2(this IServiceCollection services)
        {
        }

        public static void RegisterHttp(this IServiceCollection services)
        {
        }

        public static void RegisterApi(this IServiceCollection services)
        {
            services.AddScoped<IApi, Api.Core.Api>();
            services.AddScoped<IDashboardHttpClient, DashboardHttpClient>(); // https://blogs.msdn.microsoft.com/alazarev/2017/12/29/disposable-finalizers-and-httpclient/
            services.AddTransient<IMovieDbApi, Api.TheMovieDb.TheMovieDbApi>();
        }

        public static void RegisterStore(this IServiceCollection services)
        {
            services.AddScoped<ISettingsRepository, SettingsJsonRepository>();
            services.AddScoped<ISettingsResolver, SettingsResolver>();

            services.AddScoped(typeof(ISettingsService<>), typeof(SettingsService<>));
        }
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<ICacheService, CacheService>();

        }

        public static void RegisterJobs(this IServiceCollection services)
        {
        }
    }
}
