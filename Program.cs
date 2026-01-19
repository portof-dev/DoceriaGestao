using Microsoft.EntityFrameworkCore;
using DoceriaGestao.Data;
using DoceriaGestao.Repositories.Interface;
using DoceriaGestao.Repositories.Implementations;
using System.Globalization;



var cultureInfo = new CultureInfo("en-US");
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;



var builder = WebApplication.CreateBuilder(args);

var  connectionString= builder.Configuration.GetConnectionString("DefaultConnection");
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(connectionString)); //** instanciando a conexao com o banco de data e chamando o json
builder.Services.AddScoped<IInsumoRepository, InsumoRepository>(); //*** Registra o repositorio

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
