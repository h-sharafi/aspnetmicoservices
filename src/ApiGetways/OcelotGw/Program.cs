
var builder = WebApplication
.CreateBuilder(args);
var app = builder.Build();

app.ConfigureLogging((hostingContext, loggingbuilder) =>
{
    loggingbuilder.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
    loggingbuilder.AddConsole();
    loggingbuilder.AddDebug();
});

app.MapGet("/", () => "Hello World!");

app.Run();
