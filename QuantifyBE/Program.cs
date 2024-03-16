using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QuantifyBE.Data;
using QuantifyBE.Models;
using QuantifyBE.Repositories;
using QuantifyBE.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Configure DbContext
builder.Services.AddDbContext<QuantifyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentityCore<AppUser>().AddEntityFrameworkStores<QuantifyDbContext>().AddApiEndpoints();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Authentication
builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);

// Add Authorization
builder.Services.AddAuthorizationBuilder();

// Register Services
builder.Services.AddScoped<IFoodService, FoodService>();

// Register Repositories
builder.Services.AddScoped<IFoodRespository, FoodRepository>();

var app = builder.Build();

app.MapIdentityApi<AppUser>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();