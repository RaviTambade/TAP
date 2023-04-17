using CatalogService.Repositories.Interfaces;
using CatalogService.Repositories;
using CatalogService.Services.Interfaces;
using CatalogService.Services;
var builder = WebApplication.CreateBuilder(args);
builder.Host.ConfigureLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
});
builder.Services.AddMemoryCache();           //This adds the in-memory cache service to the dependency injection container.
// Add services to the container.
builder.Services.AddStackExchangeRedisCache(options =>{
    options.Configuration="localhost:6379";
});
builder.Services.AddControllers();
builder.Services.AddScoped<IProductRepository,ProductRepository>();
builder.Services.AddScoped<IProductService,ProductService>();
builder.Services.AddScoped<ICategoryRepository,CategoryRepository>();
builder.Services.AddScoped<ICategoryService,CategoryService>();
builder.Services.AddScoped<ISupplierRepository,SupplierRepository>();
builder.Services.AddScoped<ISupplierService,SupplierService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}
app.UseHttpsRedirection();
app.UseResponseCaching();       //Added caching middleware pipeline and configures it to cache responses
app.UseAuthorization();
app.MapControllers();
app.Run();