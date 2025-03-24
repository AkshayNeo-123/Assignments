using ClinicAppointmentSystem.Models;
using ClinicAppointmentSystem.Repository;
using ClinicAppointmentSystem.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
//using ClinicAppointmentSystem.Data;

var builder = WebApplication.CreateBuilder(args);

// Configure the database connection string (replace with your connection string)
builder.Services.AddDbContext<ClinicDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LocaldatabaseConnection")));

// Add Identity services (This will handle User authentication and role management)
//builder.Services.AddIdentity<User, IdentityRole>(options =>
//{
//    options.Password.RequireDigit = true;
//    options.Password.RequireLowercase = true;
//    options.Password.RequireUppercase = true;
//    options.Password.RequireNonAlphanumeric = false;
//    options.Password.RequiredLength = 6;
//    options.Password.RequiredUniqueChars = 1;
//})
//.AddEntityFrameworkStores<ClinicDbContext>()
//.AddDefaultTokenProviders();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<IDoctorService, DoctorService>();

// Add MVC and Razor Pages services
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages(); // This is necessary for Identity UI pages

var app = builder.Build();

// Use Authentication and Authorization middleware
//app.UseAuthentication();
//app.UseAuthorization();

// Configure routes
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Appointment}/{action=Book}/{id?}");
app.MapRazorPages(); // This is for Identity UI pages like login and registration

app.Run();
