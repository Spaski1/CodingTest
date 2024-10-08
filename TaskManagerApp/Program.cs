using Microsoft.EntityFrameworkCore;
using TaskManagerApp.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<TaskData>(options =>
{
    options.UseSqlServer("Server=SPASE\\SQLEXPRESS;Database=TaskDb;Trusted_Connection=true;TrustServerCertificate=true;");
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

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
