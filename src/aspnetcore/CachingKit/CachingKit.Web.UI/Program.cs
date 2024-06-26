using CachingKit.MemCached;
using CachingKit.Web.UI.Extensions;
using CachingKitBase;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMemcached(builder.Configuration);
// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ICacheStrategy, MemCachedCacheStrategy>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
