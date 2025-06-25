using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Curso2Legado___NetController.Data;
var builder = WebApplication.CreateBuilder(args);

// Configura o DbContext com MySQL e migrations num assembly dedicado
builder.Services.AddDbContext<CursoNetContext>(options =>
  options.UseMySql(builder.Configuration.GetConnectionString("CursoNetContext"),
    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("CursoNetContext")),
    mysqlOpts => mysqlOpts.MigrationsAssembly("Curso2LegadoNetController")
  )
);
// MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Pipeline HTTP
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
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();