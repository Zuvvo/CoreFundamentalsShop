using BethanysPieShop.Models;
using CoreFundamentalsShop.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("CoreFundamentalsShopDbContextConnection") ?? throw new InvalidOperationException("Connection string 'CoreFundamentalsShopDbContextConnection' not found.");

builder.Services.AddDbContext<CoreFundamentalsShopDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:CoreFundamentalsShopDbContextConnection"]);
});

builder.Services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<CoreFundamentalsShopDbContext>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IPieRepository, PieRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddScoped<IShoppingCart, ShoppingCart>(sp => ShoppingCart.GetCart(sp));
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();

builder.Services.AddControllersWithViews()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    }); ;


builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddServerSideBlazor();

var app = builder.Build();

app.UseStaticFiles();
app.UseSession();
app.UseAuthentication();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapDefaultControllerRoute();
app.MapRazorPages();
app.MapBlazorHub();
app.MapFallbackToPage("/app/{*catchall}", "/App/Index");

DbInitializer.Seed(app);
app.Run();
