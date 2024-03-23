using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PRN221_Project.Models;
using System;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddResponseCaching();
// Add services to the container.
builder.Services.AddRazorPages().AddRazorPagesOptions(options =>
{
    options.Conventions.AddPageApplicationModelConvention("/Pages/Index", model =>
    {
        model.Filters.Add(new ResponseCacheAttribute
        {
            Duration = 60,
            Location = ResponseCacheLocation.Client,
            NoStore = false
        });
    });
    options.Conventions.AddPageRoute("/Login", "");
});

builder.Services.AddDbContext<Prn221ProjectContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyCnn")));
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseSession();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();
app.UseResponseCaching();
app.MapRazorPages();
app.UseRequestLocalization(options =>
{
    options.DefaultRequestCulture = new RequestCulture("vi-VN");
});

app.Run();
