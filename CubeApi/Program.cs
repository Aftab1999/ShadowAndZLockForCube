// Global using directives
global using Microsoft.AspNetCore.Builder;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Hosting;
global using Microsoft.AspNetCore.Hosting;
global using Microsoft.Extensions.Configuration;

using Microsoft.EntityFrameworkCore;
using MvcDemo.Models;
using Microsoft.Extensions.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add DbContext using SQLite
builder.Services.AddDbContext<MvcDemoContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MvcDemoContext")));

// Add CORS services and configure the default policy
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policyBuilder =>
    {
        policyBuilder.WithOrigins("http://localhost:3000") // Your React application's origin
               .AllowAnyHeader()
               .AllowAnyMethod()
               .AllowCredentials(); // Include this if your requests involve credentials, like cookies or authorization headers
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Use CORS with the default policy
app.UseCors(); // This uses the default policy we've configured above

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
