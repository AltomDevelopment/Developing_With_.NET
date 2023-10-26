using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using User_Login_IdentityExample.Areas.Identity.Data;
using User_Login_IdentityExample.Data;


var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("User_Login_IdentityAuthDbContextConnection") ?? throw new InvalidOperationException("Connection string 'User_Login_IdentityAuthDbContextConnection' not found.");

builder.Services.AddDbContext<User_Login_IdentityAuthDbContext>(options =>
    options.UseSqlServer(connectionString));//Edit the connection string in AppSetting.json

builder.Services.AddDefaultIdentity<User_Login_IdentityExampleApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<User_Login_IdentityAuthDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.Configure<IdentityOptions>(options => //Changing the requirements for passwords
{
    options.Password.RequireUppercase = false;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
