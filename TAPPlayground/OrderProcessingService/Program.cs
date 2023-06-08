
using OrderProcessingService.Helpers;
using OrderProcessingService.Repositories;
using OrderProcessingService.Repositories.Interfaces;
using OrderProcessingService.Services;
using OrderProcessingService.Services.Interfaces;


var builder = WebApplication.CreateBuilder(args);
//Configure logging

builder.Host.ConfigureLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
});
builder.Services.AddMemoryCache();
// Add services to the container.
builder.Services.AddCors();
builder.Services.AddControllers();
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

builder.Services.AddTransient<IOrderRepository,OrderRepository>();
builder.Services.AddTransient<IOrderService,OrderService>();
builder.Services.AddTransient<IOrderDetailsRepository,OrderDetailsRepository>();
builder.Services.AddTransient<IOrderDetailsService,OrderDetailsService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();
app.UseMiddleware<JwtMiddleware>();
app.MapControllers();

app.Run();
