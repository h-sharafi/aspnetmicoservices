
WebApplicationBuilder? builder = WebApplication
.CreateBuilder(args);
builder.Host.ConfigureLogging((hostingContext, loggingbuilder) =>
{
    loggingbuilder.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
    loggingbuilder.AddConsole();
    loggingbuilder.AddDebug();
});
var app = builder.Build();
app.MapGet("/", () => "Hello World!");

app.Run();
