using Microsoft.EntityFrameworkCore;
using ProjektPraktyki_2._0.Models;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.\

builder.Services.AddDbContext<CompanyContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("CompanyCS")));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

var appBuilder = WebApplication.CreateBuilder(args);

// Dodaj us³ugi do kontenera.
appBuilder.Services.AddControllersWithViews();

var bApp = builder.Build();

// Skonfiguruj potok HTTP.
if (bApp.Environment.IsDevelopment())
{
    bApp.UseDeveloperExceptionPage();
}
else
{
    bApp.UseExceptionHandler("/Home/Error");
    bApp.UseHsts();
}

bApp.UseHttpsRedirection();
bApp.UseStaticFiles();

bApp.UseRouting();

bApp.UseAuthorization();

bApp.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseSpa(spa =>
{
    spa.Options.SourcePath = "ClientApp";

    if (bApp.Environment.IsDevelopment())
    {
        spa.UseProxyToSpaDevelopmentServer("http://localhost:3000");
    }
});

bApp.Run();
