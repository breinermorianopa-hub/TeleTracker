using Microsoft.EntityFrameworkCore;
using TeleTracker.Data;

var builder = WebApplication.CreateBuilder(args);

// 1. Agregar servicios al contenedor.
builder.Services.AddControllersWithViews();

// 2. Registrar el DbContext para PostgreSQL (pgAdmin)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configurar el pipeline de solicitudes HTTP.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // El valor predeterminado de HSTS es 30 días. Puedes cambiar esto para escenarios de producción.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
