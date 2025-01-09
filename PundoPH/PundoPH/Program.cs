using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using PundoPH.Data;
using PundoPH.Helper;
using PundoPH.Model;
using PundoPH.ViewModel;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddSingleton<LoginModel>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<ContributionService>();
builder.Services.AddScoped<MessageHelper>();
builder.Services.AddScoped<LoginHelper>();
builder.Services.AddScoped<WithdrawService>();
builder.Services.AddScoped<IWithdrawViewModel, WithdrawViewModel>();

// Add services to the container
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
