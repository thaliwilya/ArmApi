using ArmApi.Interface;
using NLog;
using NLog.Web;
using ArmApi.Services.GoogleAPI;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

try
{

    var builder = WebApplication.CreateBuilder(args);
    //var configuration = builder.Services.BuildServiceProvider().GetRequiredService<IConfiguration>();
    //var name = configuration.GetValue<string>("aa");
    // Add services to the container.
    builder.Services.AddMemoryCache(options =>
    {
    // Overall 1024 size (no unit)
        options.SizeLimit = 1024;
    });
    builder.Services.AddControllers();

    builder.Services.AddScoped<IGooglePlacesAPI, GoolgePlacesAPI>();


    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    // NLog: Setup NLog for Dependency injection
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception exception)
{
    // NLog: catch setup errors
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    NLog.LogManager.Shutdown();
}
