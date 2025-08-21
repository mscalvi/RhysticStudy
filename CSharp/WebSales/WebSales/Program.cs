using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebSales.Data;
using WebSales.Services;

var builder = WebApplication.CreateBuilder(args);

var connectionStr = "server=localhost;userid=mscalvi;password=yzqtzxs5;database=WebSalesDB";
builder.Services.AddDbContext<WebSalesContext>(options =>
    options.UseMySql(connectionStr, ServerVersion.AutoDetect(connectionStr)));

// Registrar o SeedingService
builder.Services.AddScoped<SeedingService>();

// Registrar os Services
builder.Services.AddScoped<PlayersServices>();
builder.Services.AddScoped<TournamentsServices>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Aplicar migrações automaticamente ao iniciar a aplicação
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<WebSalesContext>();
    dbContext.Database.Migrate();  // Aplica as migrações pendentes

    var seedingService = scope.ServiceProvider.GetRequiredService<SeedingService>();
    seedingService.Seed(); // Popula o banco de dados
}

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