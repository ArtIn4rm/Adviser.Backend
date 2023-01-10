using Adviser.Persistence;
using Adviser.WebApi;

var builder = WebApplication.CreateBuilder(args);
Startup.Init(builder)
    .ConfigureServices();
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    try
    {
        var context = serviceProvider.GetRequiredService<AppDbContext>();
        DbInitializer.Initialize(context);
        Startup.ConfigureApplicationPipeline(app);
    }
    catch (InvalidOperationException exception)
    {
        Console.WriteLine(exception.Message);
    }
}

