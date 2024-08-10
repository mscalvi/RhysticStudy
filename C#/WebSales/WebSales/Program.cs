using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebSales.Data;

var builder = WebApplication.CreateBuilder(args);

var connectionStr = "server=localhost;userid=mscalvi;password=yzqtzxs5;database=WebSalesDB";
builder.Services.AddDbContext<WebSalesContext>(options =>
    options.UseMySql(connectionStr, ServerVersion.AutoDetect(connectionStr)));
//options.UseSqlServer(builder.Configuration.GetConnectionString("WebSalesContext") ?? throw new InvalidOperationException("Connection string 'WebSalesContext' not found.")));

// Registrar o SeedingService
builder.Services.AddScoped<SeedingService>();

// Registrar o PlayerServices
builder.Services.AddScoped<IPlayersServices, PlayersServices>();

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

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Chamar o método de seeding para popular o banco de dados
using (var scope = app.Services.CreateScope())
{
    var seedingService = scope.ServiceProvider.GetRequiredService<SeedingService>();
    seedingService.Seed();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
