using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<eBilet2.Data.eBilet2Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("eBilet2Context")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => { options.SignIn.RequireConfirmedAccount = true; options.Password = new PasswordOptions { RequireDigit = false, RequiredLength = 1, RequireLowercase = false, RequiredUniqueChars = 1, RequireNonAlphanumeric = false, RequireUppercase = false }; })
    .AddEntityFrameworkStores<eBilet2.Data.eBilet2Context>();

// Add services to the container.
builder.Services.AddControllersWithViews();

// DI
//builder.Services.AddTransient<ICustomerRepository, eBilet2.SimpleCustomerRepository>();
//builder.Services.AddTransient<ITicketRepository, eBilet2.SimpleTicketRepository>();
//builder.Services.AddTransient<IEventRepository, eBilet2.SimpleEventRepository>();

builder.Services.AddTransient<ICustomerRepository, eBilet2.EfCustomerRepository>();
builder.Services.AddTransient<ITicketRepository, eBilet2.EfTicketRepository>();
builder.Services.AddTransient<IEventRepository, eBilet2.EfEventRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseRouting();
app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
