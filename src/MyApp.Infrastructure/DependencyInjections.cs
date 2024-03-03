using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Application.Core.Services;
using MyApp.Domain.Core.Repositories;
using MyApp.Infrastructure.Data;
using MyApp.Infrastructure.Identity.Models;
using MyApp.Infrastructure.Repositories;
using MyApp.Infrastructure.Services;
using System;

namespace MyApp.Infrastructure
{
    public static class DependencyInjections
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddIdentity<AppUser, AppRole>()
        .AddEntityFrameworkStores<MyAppDbContext>();
            services.AddDbContextPool<MyAppDbContext>(options =>
                options.UseSqlServer(
"Data Source=bi-qc-01;Initial Catalog=SalesBuzz_Schema_Test_bak;User ID=PDASYNC;Password=PDASYNC;MultipleActiveResultSets=true;Encrypt=False",
x => x.MigrationsAssembly("MyApp.Infrastructure")));
            services.AddScoped(typeof(IBaseRepository<,>), typeof(BaseRepository<,>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<ILoggerService, LoggerService>();
        }

        public static void MigrateDatabase(IServiceProvider serviceProvider)
        {
            var dbContextOptions = serviceProvider.GetRequiredService<DbContextOptions<MyAppDbContext>>();

            using (var dbContext = new MyAppDbContext(dbContextOptions))
            {
                dbContext.Database.Migrate();
            }
        }
    }
}