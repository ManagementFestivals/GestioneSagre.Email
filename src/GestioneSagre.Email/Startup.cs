using GestioneSagre.Email.Shared.Models;
using GestioneSagre.Messaging.RabbitMq;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.OpenApi.Models;

namespace GestioneSagre.Email;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddCors(options =>
        {
            options.AddPolicy("GestioneSagre.Email", policy =>
            {
                policy.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
            });
        });

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(config =>
        {
            config.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Gestione Sagre Email",
                Version = "v1"
            });
        });

        services.Configure<KestrelServerOptions>(Configuration.GetSection("Kestrel"));

        services.AddRabbitMq(settings =>
        {
            settings.ConnectionString = Configuration.GetConnectionString("RabbitMQ");
            settings.ExchangeName = Configuration.GetValue<string>("AppSettings:ApplicationName");
            settings.QueuePrefetchCount = Configuration.GetValue<ushort>("AppSettings:QueuePrefetchCount");
        }, queues =>
        {
            queues.Add<EmailRequest>();
        });
    }

    public void Configure(WebApplication app)
    {
        IWebHostEnvironment env = app.Environment;

        app.UseCors("GestioneSagre.Email");

        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "Gestione Sagre Email v1");
        });

        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}