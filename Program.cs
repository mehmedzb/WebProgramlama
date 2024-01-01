using HastaneWeb.Data;
using HastaneWeb.Models;
using HastaneWeb.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using System.Globalization;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// add admin user
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultUI()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<LanguageService>();
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.AddMvc()
    .AddViewLocalization(Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat.Suffix)
    .AddDataAnnotationsLocalization(options => options.DataAnnotationLocalizerProvider = (type,factory) => 
    {
        var assemblyName = new AssemblyName(typeof(SharedResource).GetTypeInfo().Assembly.FullName);
        return factory.Create(nameof(SharedResource), assemblyName.Name);
    });




builder.Services.Configure
<RequestLocalizationOptions>(options =>
    {
    var supportedCultures = new[]
    {
        new CultureInfo("en-US"),
        new CultureInfo("tr-TR"),
        new CultureInfo("fr-FR")
    };

    options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("tr-TR");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
    options.RequestCultureProviders.Insert(0, new QueryStringRequestCultureProvider());

});

builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();


UserManager<IdentityUser> userManager = builder.Services.BuildServiceProvider().GetRequiredService<UserManager<IdentityUser>>();
RoleManager<IdentityRole> roleManager = builder.Services.BuildServiceProvider().GetRequiredService<RoleManager<IdentityRole>>();

string adminEmail = "b2111@sakarya.edu.tr";
string adminPassword = "Mehmed#123456";
string roleName = "Admin";

var roleExist = await roleManager.RoleExistsAsync(roleName);

if (!roleExist)
{
    Console.WriteLine("Admin role not found. Creating...");
    await roleManager.CreateAsync(new IdentityRole(roleName));
}

var user = await userManager.FindByEmailAsync(adminEmail);

if (user == null)
{
    Console.WriteLine("Admin user not found. Creating...");
    user = new IdentityUser { UserName = adminEmail, Email = adminEmail };
    user.EmailConfirmed = true;
    await userManager.CreateAsync(user, adminPassword);
    await userManager.AddToRoleAsync(user, roleName);
}

var supportedCultures = new[]
{
    new CultureInfo("en-US"),
    new CultureInfo("tr-TR")
};

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseRequestLocalization(app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
