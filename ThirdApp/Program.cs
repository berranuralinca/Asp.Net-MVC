using Microsoft.EntityFrameworkCore;
using ThirdApp.Data;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllersWithViews(); //services
builder.Services.AddDbContext<ThirdAppContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionStrings")));


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
