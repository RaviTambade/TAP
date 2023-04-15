using CRMService.Repositories;
using CRMService.Repositories.Interfaces;
using CRMService.Services;
using CRMService.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Host.ConfigureLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
});

builder.Services.AddMemoryCache();
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<ICustomerRepository,CustomerRepository>();
builder.Services.AddTransient<ICustomerService,CustomerService>();
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

app.UseHttpsRedirection();
app.UseResponseCaching();
app.UseAuthorization();
app.MapControllers();
app.Run();
