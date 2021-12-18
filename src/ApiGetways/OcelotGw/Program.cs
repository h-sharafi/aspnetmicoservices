
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

WebApplicationBuilder? builder = WebApplication
.CreateBuilder(args);
builder.Host.ConfigureLogging((hostingContext, loggingbuilder) =>
{
    loggingbuilder.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
    loggingbuilder.AddConsole();
    loggingbuilder.AddDebug();
});

builder.Services.AddOcelot();
var app = builder.Build();
app.MapGet("/", () => "Hello World!");
app.UseOcelot();
app.Run();
