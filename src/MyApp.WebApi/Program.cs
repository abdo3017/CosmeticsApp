using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MyApp.Infrastructure.Data.Configurations;
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

app.UseAuthentication();
app.UseAuthorization();
app.UseCors(allowedOrigines);
app.MapControllers();

//using (var scope = app.Services.CreateScope())
//{
//    MyApp.Infrastructure.DependencyInjections.MigrateDatabase(scope.ServiceProvider);
//}

app.Run();
