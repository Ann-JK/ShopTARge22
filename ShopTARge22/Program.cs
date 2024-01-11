using ShopTARge22.Data;
using Microsoft.EntityFrameworkCore;
using ShopTARge22.Core.ServiceInterface;
using ShopTARge22.ApplicationServices.Services;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Identity;
using ShopTARge22.Core.Domain;
using ShopTARge22.Security;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ISpaceshipsServices, SpaceshipsServices>();
builder.Services.AddScoped<IFileServices, FileServices>();
builder.Services.AddScoped<IWeatherForecastServices, WeatherForecastServices>();
builder.Services.AddScoped<IRealEstateServices, RealEstateServices>();
builder.Services.AddScoped<IKindergartensServices, KindergartensServices>();
builder.Services.AddScoped<ICocktailServices, CocktailServices>();
builder.Services.AddScoped<IAccuWeatherForecastsServices, AccuWeatherForecastsServices>();
builder.Services.AddRazorPages();

builder.Services.AddDbContext<ShopTARge22Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => 
    {
        options.SignIn.RequireConfirmedAccount = true;
        options.Password.RequiredLength = 3;

        options.Tokens.EmailConfirmationTokenProvider = "CustomEmailConfirmation";
        options.Lockout.MaxFailedAccessAttempts = 3;
        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2);
    })
    .AddEntityFrameworkStores<ShopTARge22Context>()
    .AddDefaultTokenProviders()
    .AddTokenProvider<DataProtectorTokenProvider<ApplicationUser>>("CustomEmailConfirmation")
    .AddDefaultUI();

//all tokens
builder.Services.Configure<DataProtectionTokenProviderOptions>
    (o => o.TokenLifespan = TimeSpan.FromHours(5));

//email tokens confirmation
builder.Services.Configure<CustomEmailConfigurationTokenProviderOptions>
    (o => o.TokenLifespan = TimeSpan.FromDays(3));



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

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider
    (Path.Combine(builder.Environment.ContentRootPath, "multipleFileUpload")),
    RequestPath = "/multipleFileUpload"
});
;

app.UseRouting();

builder.Services.AddAuthentication()
    .AddFacebook(options => 
    {
        options.AppId = "";
        options.AppSecret = "";
    })
    .AddGoogle(options =>
    {
        options.ClientId = "";
        options.ClientSecret = "";
    });

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

//landing page
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
