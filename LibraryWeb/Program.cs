using Microsoft.EntityFrameworkCore;
using Library.DataAccess;
using Library.DataAccess.Repository;
using Library.DataAccess.Repository.IRepository;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddRazorPages()
//   .AddRazorRuntimeCompilation();

// Add services to the container.
builder.Services.AddControllersWithViews();
//Add DbContext Services
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


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
