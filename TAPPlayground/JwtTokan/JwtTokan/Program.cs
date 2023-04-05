using ECommerceApp.Helpers;
using ECommerceApp.Repositories;
using ECommerceApp.Repositories.Interfaces;
using ECommerceApp.Services;
using ECommerceApp.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
  

  
builder.Services.AddControllers();
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
builder.Services.AddTransient<IUserRepository,UserRepository>();
builder.Services.AddTransient<IUserService,UserService>();

builder.Services.AddCors();
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
// builder.Services.AddTransient<IOrderDetailsRepository,OrderDetailsRepository>();
builder.Services.AddTransient<IOrderDetailsRepository,OrderDetailsORMRepository>();
builder.Services.AddTransient<IOrderDetailsService,OrderDetailsService>();
builder.Services.AddTransient<IShipperRepository,ShipperRepository>();
builder.Services.AddTransient<IShipperService,ShipperService>();
builder.Services.AddTransient<ITransactionRepository,TransactionRepository>();
builder.Services.AddTransient<ITransactionService,TransactionService>();
builder.Services.AddTransient<IMiniStatementRepository,MiniStatementRepository>();
builder.Services.AddTransient<IMiniStatementService,MiniStatementService>();
builder.Services.AddTransient<IEmployeeRepository,EmployeeRepository>();
builder.Services.AddTransient<IEmployeeService,EmployeeService>();
builder.Services.AddTransient<IAccountRepository,AccountRepository>();
builder.Services.AddTransient<IAccountService,AccountService>();
builder.Services.AddTransient<IPaymentRepository,PaymentRepository>();
builder.Services.AddTransient<IPaymentService,PaymentService>();
builder.Services.AddTransient<ISupplierRepository,SupplierRepository>();
//builder.Services.AddTransient<ISupplierRepository,SupplierORMRepository>();
builder.Services.AddTransient<ISupplierService,SupplierService>();
// builder.Services.AddTransient<ISecureRepository,SecureRepository>();
// builder.Services.AddTransient<ISecureService,SecureService>();
builder.Services.AddTransient<ICustomerAccountRepository,CustomerAccountRepository>();
builder.Services.AddTransient<ICustomerAccountService,CustomerAccountService>();
builder.Services.AddTransient<ICustomerORMRepository,CustomerORMRepository>();
builder.Services.AddTransient<ICustomerORMService,CustomerORMService>();
builder.Services.AddTransient<ICategoryRepository,CategoryRepository>();
builder.Services.AddTransient<ICategoryService,CategoryService>();

// builder.Services.AddSession(options =>{
//     options.IdleTimeout=TimeSpan.FromMinutes(10);
//     options.Cookie.HttpOnly=true;
//     options.Cookie.IsEssential=true;
// });


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

app.UseAuthorization();
app.UseAuthentication();    
         
app.UseMiddleware<JwtMiddleware>();

app.MapControllers();

app.Run();