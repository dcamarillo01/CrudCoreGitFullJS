using DL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString =
    builder.Configuration.GetConnectionString("EjercicioGitAbril2025")
        ?? throw new InvalidOperationException("Connection string"
        + "'EjercicioGitAbril2025' not found.");

//Hacer inyeccion de dependencia(connection string)
builder.Services.AddDbContext<EjercicioGitAbril2025Context>(options =>
    options.UseSqlServer(connectionString));

//Donde va a vivir la coneccion.

builder.Services.AddScoped<BL.Usuario>();


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
