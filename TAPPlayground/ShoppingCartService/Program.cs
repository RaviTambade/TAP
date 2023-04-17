using ShoppingCartService.Repositories;
using ShoppingCartService.Repositories.Interfaces;
using ShoppingCartService.Services;
using ShoppingCartService.Services.Interfaces;
using Serilog;
using ShoppingCartService.Controllers;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

builder.Services.AddControllers();


builder.Services.AddStackExchangeRedisCache(options =>{
    options.Configuration="localhost:6379";
});

builder.Services.AddScoped<ICartRepository,CartRepository>();
builder.Services.AddScoped<ICartService,CartService>();
builder.Services.AddScoped<RedisCartController>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSerilogRequestLogging();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();