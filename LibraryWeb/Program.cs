using Microsoft.EntityFrameworkCore;
using Library.DataAccess;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddRazorPages()
//   .AddRazorRuntimeCompilation();

// Add services to the container.
builder.Services.AddControllersWithViews();
//Add DbContext Services
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));
//add Razor runtime compilation for .net before v6.0


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

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
