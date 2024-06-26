using AmourLink.Infrastructure.Extensions;
using AmourLink.Infrastructure.Middlewares;
using AmourLink.Swipe.Data.Context;
using AmourLink.Swipe.Extensions;

namespace AmourLink.Swipe;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllersConfigured();
        
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddDataServices<ApplicationDbContext>(builder.Configuration);
        builder.Services.AddServices(builder.Configuration);
        
        builder.Services.AddAuthenticationConfigured(builder.Configuration);
        builder.Services.AddAuthorization();
        
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGenConfigured("AmourLink.Swipe");
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

        app.Run();
    }
}