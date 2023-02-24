using E_AgroServiceDemo.Repositories;
using E_AgroServiceDemo.Repositories.Interfaces;
using E_AgroServiceDemo.Services.Interfaces;
using E_AgroServiceDemo.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IUserRepository,UserRepository>();
builder.Services.AddTransient<IUserService,UserService>();
builder.Services.AddTransient<IFarmerRepository,FarmerRepository>();
builder.Services.AddTransient<IFarmerService,FarmerService>();

builder.Services.AddControllersWithViews();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
