using Microsoft.EntityFrameworkCore;
using ClinincAppointmentSys; // Replace with your actual namespace
using Microsoft.Extensions.DependencyInjection;
using ClinincAppointmentSys.Repositories;
using ClinincAppointmentSys.Services;
using System;
using ClinincAppointmentSys.Data;

var builder = WebApplication.CreateBuilder(args);


// Add DbContext to the DI container (replace with your actual DbContext)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register Repositories
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Register Services
builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<IUserService, UserService>();



// Add services to the container.
builder.Services.AddControllersWithViews(); // If you're using MVC or API controllers

builder.Services.AddDistributedMemoryCache();
// Add session services
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Session timeout
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddDistributedMemoryCache();
builder.Services.AddHttpContextAccessor(); 

var app = builder.Build();
app.UseSession();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
