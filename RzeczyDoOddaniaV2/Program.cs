using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using RzeczyDoOddaniaV2.Data;
using RzeczyDoOddaniaV2.Models;
using RzeczyDoOddaniaV2.Services;
using RzeczyDoOddaniaV2.Interfaces;
using RzeczyDoOddaniaV2.Repositories;

var builder = WebApplication.CreateBuilder(args);
var connectionStringLogin = builder.Configuration.GetConnectionString("Login");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionStringLogin));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();;


var connectionStringOferty = builder.Configuration.GetConnectionString("Oferty");

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(connectionStringOferty));

builder.Services.AddTransient<IOfertyDBService, OfertyDBService>();
builder.Services.AddTransient<IOfertyDBRepository, OfertyDBRepository>();

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddTransient<IEmailSender, SendGridEmailSender>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
