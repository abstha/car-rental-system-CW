using car_system.Controllers.Data;
using car_system.Controllers.Services;
using car_system.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;


var builder = WebApplication.CreateBuilder(args);

// Add Swagger generator
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DbContext config
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer("Data Source=LAPTOP-ERS22E1S\\SQLEXPRESS;Initial Catalog=coursework-database;Integrated Security=True;Pooling=False;Encrypt=False"));

builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<IRentalService, RentalService>();
builder.Services.AddScoped<IOfferService, OfferService>();
builder.Services.AddScoped<IDamageService, DamageService>();
builder.Services.AddScoped<IHomeService, HomeService>();
//builder.Services.AddScoped<IAttachmentService, AttachmentService>();


builder.Services.AddIdentity<Users, UserRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<RoleManager<UserRole>>();

builder.Services.AddSession();


// Add services to the container.
builder.Services.AddControllersWithViews();

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

ApplicationDbInitializer.Seed(app);

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API Name v1");
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseCors();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
