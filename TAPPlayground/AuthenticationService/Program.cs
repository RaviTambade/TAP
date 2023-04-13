
using AuthenticationService.Repositories;
using AuthenticationService.Repositories.Interfaces;
using AuthenticationService.Services;
using AuthenticationService.Services.Interfaces;
using AuthenticationService.Helpers;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();

builder.Services.AddControllers();
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
builder.Services.AddTransient<IUserRepository,UserRepository>();
builder.Services.AddTransient<IUserService,UserService>();

builder.Services.AddCors();

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
app.MapControllers();
app.Run();
