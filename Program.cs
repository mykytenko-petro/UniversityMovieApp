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

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapControllers();

app.Run();
