using BankingService.Helpers;
using BankingService.Repositories;
using BankingService.Repositories.Interfaces;
using BankingService.Services;
using BankingService.Services.Interfaces;



var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
});
builder.Services.AddStackExchangeRedisCache(options =>{
    options.Configuration="localhost:6080";
});
builder.Services.AddMemoryCache();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

builder.Services.AddTransient<IAccountRepository,AccountRepository>();
builder.Services.AddTransient<IAccountService,AccountService>();
builder.Services.AddTransient<ITransactionRepository,TransactionRepository>();
builder.Services.AddTransient<ITransactionService,TransactionService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseResponseCaching();

app.UseAuthentication();
app.UseMiddleware<JwtMiddleware>();

app.MapControllers();

app.Run();
