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

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.MapControllers();

app.Run();
