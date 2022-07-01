using Microsoft.EntityFrameworkCore;
using StartBootstrap.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


builder.Services.AddDbContext<AppDbContext>
(opt => opt.UseSqlServer(connectionString));

var app = builder.Build();

app.UseStaticFiles();
//app.UseDefaultFiles();
app.UseRouting();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.MapControllerRoute(
    name:"default",
    pattern:"{controller=Home}/{action=Index}"

 );
//app.MapGet("/", () => "Hello World!");
app.MapDefaultControllerRoute();

app.Run();
