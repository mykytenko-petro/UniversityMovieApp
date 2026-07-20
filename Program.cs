using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UniversityMovieApp.Models;
using UniversityMovieApp.Services;

// services
var builder = WebApplication.CreateBuilder(args);

// template engine
var mvcBuilder = builder.Services.AddControllersWithViews();
if (builder.Environment.IsDevelopment())
{
    mvcBuilder.AddRazorRuntimeCompilation();
}

// database
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlite("Data Source=app.db"));
}
else
{
    // TODO: add postgresql support for production
    throw new NotImplementedException();
}

// auth
builder.Services.AddDefaultIdentity<IdentityUser>(options => {
    
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 1;
    options.Password.RequiredUniqueChars = 0;
})
.AddEntityFrameworkStores<AppDbContext>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.SecurePolicy = CookieSecurePolicy.None; // Allows cookies over HTTP
});

// media
builder.WebHost.ConfigureKestrel(options =>
{
    options.Limits.MaxRequestBodySize = 5368709120; 
});

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddScoped<IMediaService, DevelopmentMediaService>();
}
else
{
    builder.Services.AddScoped<IMediaService, CloudinaryMediaService>();
}

var app = builder.Build();

// app config
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();
app.MapControllers();

app.Run();
