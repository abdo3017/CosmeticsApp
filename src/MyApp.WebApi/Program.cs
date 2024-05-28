using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyApp.Infrastructure.Data.Configurations;
using System.Globalization;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var allowedOrigines = "myOri";
var appSettings = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .Build();

MyApp.Application.DependencyInjections.ConfigureServices(builder.Services);
MyApp.Infrastructure.DependencyInjections.ConfigureServices(builder.Services, appSettings);

builder.Services.AddLocalization(options => options.ResourcesPath = @"src\\MyApp.Domain\\Resources");


builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[]
    {
        new CultureInfo("en"),
        new CultureInfo("ar")
    };

    options.DefaultRequestCulture = new RequestCulture(culture: "en", uiCulture: "en");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

builder.Services.AddCors(op =>
{
    op.AddPolicy(allowedOrigines, po =>
    {
        po.AllowAnyMethod();
        po.AllowAnyHeader();
        po.AllowAnyOrigin();
    });
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseCors(allowedOrigines);
app.UseRouting();

var locOptions = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(locOptions.Value);

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

//using (var scope = app.Services.CreateScope())
//{
//    MyApp.Infrastructure.DependencyInjections.MigrateDatabase(scope.ServiceProvider);
//}

app.Run();
