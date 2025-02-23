using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MapProject.Data;
using MapProject.Models;
using MapProject.Infrastructure.AppDbContext;
using MapProject.Application.Interfaces.Repositories;
using MapProject.Infrastructure.Repositories;
using MapProject.Application.Interfaces;
using MapProject.Application.Interfaces.Services;
using MapProject.Application.Services;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContextConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();

builder.Services.AddScoped<IChartService, ChartService>();
builder.Services.AddScoped<IChartRepository, ChartRepository>();

builder.Services.AddScoped<ISupportService, SupportService>();
builder.Services.AddScoped<ISupportRepository, SupportRepository>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireUppercase = false;
});

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
app.MapRazorPages();


app.Run();
