using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using PundoPH.Data;
using PundoPH.Helper;
using PundoPH.Model;
using PundoPH.Service;
using PundoPH.ViewModel;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();// TODO: Need to delete soon
builder.Services.AddSingleton<LoginModel>();
builder.Services.AddScoped<UserService>();// TODO: Need to delete soon
builder.Services.AddScoped<ContributionService>();// TODO: Need to delete soon
builder.Services.AddScoped<MessageHelper>();
builder.Services.AddScoped<LoginHelper>();
builder.Services.AddScoped<WithdrawService>();// TODO: Need to delete soon
builder.Services.AddScoped<IWithdrawViewModel, WithdrawViewModel>();
builder.Services.AddScoped<Service>();// All services class are move to this Service class

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
