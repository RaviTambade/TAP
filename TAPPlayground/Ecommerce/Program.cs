using ECommerceApp.Repositories;
using ECommerceApp.Repositories.Interfaces;
using ECommerceApp.Services;
using ECommerceApp.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<ICustomerRepository,CustomerRepository>();
builder.Services.AddTransient<ICustomerService,CustomerService>();
builder.Services.AddTransient<IUserRepository,UserRepository>();
builder.Services.AddTransient<IUserService,UserService>();
builder.Services.AddTransient<IProductRepository,ProductRepository>();
builder.Services.AddTransient<IProductService,ProductService>();
builder.Services.AddTransient<IAddressRepository,AddressRepository>();
builder.Services.AddTransient<IAddressService,AddressService>();
builder.Services.AddTransient<IDashboardRepository,DashboardRepository>();
builder.Services.AddTransient<IDashboardService,DashboardService>();



builder.Services.AddSession(options =>{
    options.IdleTimeout=TimeSpan.FromMinutes(10);
    options.Cookie.HttpOnly=true;
    options.Cookie.IsEssential=true;
});

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
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
