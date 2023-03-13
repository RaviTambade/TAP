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
builder.Services.AddTransient<IOrderRepository,OrderRepository>();
builder.Services.AddTransient<IOrderService,OrderService>();
builder.Services.AddTransient<IOrderDetailsRepository,OrderDetailsRepository>();
builder.Services.AddTransient<IOrderDetailsService,OrderDetailsService>();
builder.Services.AddTransient<IShipperRepository,ShipperRepository>();
builder.Services.AddTransient<IShipperService,ShipperService>();
<<<<<<< HEAD
builder.Services.AddTransient<IAccountRepository,AccountRepository>();
builder.Services.AddTransient<IAccountService,AccountService>();
=======
<<<<<<< HEAD
builder.Services.AddTransient<IPaymentRepository,PaymentRepository>();
builder.Services.AddTransient<IPaymentService,PaymentService>();
=======
builder.Services.AddTransient<ISupplierRepository,SupplierRepository>();
builder.Services.AddTransient<ISupplierService,SupplierService>();
>>>>>>> 5e3bd213559366d2874caa0519a41a6e8964a545
>>>>>>> 4f93cab34277b8835b3bbc7d3dd04b2ca3d628db

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
