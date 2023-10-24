using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Veturilo.API.Extensions;
using Veturilo.API.Mapper;
using Veturilo.API.Services;
using Veturilo.Application.Services;
using Veturilo.Infrastructure.Entities;
using Veturilo.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IBaseRepository<Bike>, BaseListRepository<Bike>>();
builder.Services.AddSingleton<IBaseRepository<User>, BaseListRepository<User>>();
builder.Services.AddSingleton<IBaseRepository<Station>, BaseListRepository<Station>>();
builder.Services.AddSingleton<IBaseRepository<Rent>, BaseListRepository<Rent>>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRentService, RentService>();
builder.Services.AddSingleton<IPasswordService, HmacPasswordService>();
builder.Services.AddScoped<ITokenService, TokenService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();
builder.Services.AddAutoMapper(typeof(MapperProfile));
builder.Services.AddJwtAuthentication(builder.Configuration["Jwt:Key"]);


builder.Services.AddCors(builder =>
{
    builder.AddDefaultPolicy(opt =>
    {
        opt.AllowAnyOrigin().WithMethods("GET", "POST").AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.SeedStations();
app.SeedUsers();
app.SeedBikes();

app.Run();
