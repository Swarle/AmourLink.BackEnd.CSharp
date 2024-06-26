using AmourLink.Infrastructure.Extensions;
using AmourLink.Infrastructure.Middlewares;
using AmourLink.Recommendation.Data.Context;
using AmourLink.Recommendation.Extensions;
using Newtonsoft.Json.Converters;

namespace AmourLink.Recommendation;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllersConfigured();
        
        builder.Services.AddDataServices<ApplicationDbContext>(builder.Configuration);
        builder.Services.AddServices(builder.Configuration);

        builder.Services.AddAuthenticationConfigured(builder.Configuration);
        builder.Services.AddAuthorization();
        
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGenConfigured("AmourLink.Recommendation");

        var app = builder.Build();
        
        if (app.Environment.IsDevelopment() || app.Environment.IsEnvironment("Local"))
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseApiExceptionMiddleware();

        app.UseHttpsRedirection();
        
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.SeedDatabase();
        app.Run();
    }
}