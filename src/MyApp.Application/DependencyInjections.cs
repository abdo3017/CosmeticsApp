using Microsoft.Extensions.DependencyInjection;
using MyApp.Application.Core.Services;
using MyApp.Application.Interfaces;
using MyApp.Application.Services;
using MyApp.Domain.Service;

namespace MyApp.Application
{
    public static class DependencyInjections
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseService<,>), typeof(BaseService<,>));
            services.AddScoped<IServiceManager, ServiceManager>();
        }
    }
}