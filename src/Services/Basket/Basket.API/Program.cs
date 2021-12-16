using Basket.API.GrpcServices;
using Basket.API.Repositories;
using Dicount.Grpc.Protos;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetValue<string>("CacheSettings:ConnectionString");
});
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<IBasketRepository, BasketRepository>();
// grpc setting 
builder.Services.AddGrpcClient<DoscountProtoService.DoscountProtoServiceClient>
    (opt => opt.Address = new Uri(builder.Configuration["GrpcSettings:DiscountUrl"]));

// rabbitmq settign
builder.Services.AddMassTransit(config =>
{
    config.UsingRabbitMq((ctx, cfg) =>
    {
        cfg.Host(builder.Configuration ["EventBusSettings:HostAddress"]);
    });
});

builder.Services.AddMassTransitHostedService();


builder.Services.AddScoped<DiscountGrpcService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
