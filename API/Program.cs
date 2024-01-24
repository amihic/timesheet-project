using TimeSheet.Service;
using TimeSheet.Data;
using Microsoft.EntityFrameworkCore;
using API;
using TimeSheet.Domain.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using API.Controllers;
using Microsoft.OpenApi.Models;
using TimeSheet.Data.Entities;
using API.CustomAuthorizationFilter;
using Microsoft.AspNetCore.Identity;
using TimeSheet.Domain.Model;

var builder = WebApplication.CreateBuilder(args);

//builder.WebHost.UseUrls("https://localhost:5001");
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// Dodajte AutoMapper konfiguraciju u DI kontejner
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Dodajte DbContext direktno u DI kontejner
builder.Services.AddDbContext<TimeSheetDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


//kada necu autorizaciju, samo da zakomentarisem ovaj blok
/*builder.Services.AddControllers(options =>
{
    options.Filters.Add(typeof(CustomAuthorizationFilter));
});*/

// Add services to the container.

builder.Services.AddControllers();

// Registracija servisa u DI kontejneru
builder.Services.AddScoped<UserController>();

builder.Services.AddScoped<IJwtService, JwtService>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IClientService, ClientService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IProjectService, ProjectService>();

builder.Services.AddScoped<IActivityRepository, ActivityRepository>();
builder.Services.AddScoped<IActivityService, ActivityService>();

builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

//za auth
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!)),
        RoleClaimType = "Role"
    };
});




builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => //swagger sa authorize 
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "TimeSheet API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
{
    {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            },
            Scheme = "oauth2",
            Name = "Bearer",
            In = ParameterLocation.Header,

        },
        new List<string>()
    }
});
});

var app = builder.Build();

//app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();



app.Run();
