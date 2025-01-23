using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using NzWalks.API.Data;
using NzWalks.API.Mapper;
using NzWalks.API.Repository;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var securitySchemes = new OpenApiSecurityScheme
    {
        Name = "JWT Authentication",
        Description = "Enter a valid JWT token",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }

    };
    options.AddSecurityDefinition(securitySchemes.Reference.Id, securitySchemes);
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {securitySchemes, new string[] { } }
    });

});

builder.Services.AddDbContext<NzWalksDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("NzWalksOldConnection"));
});

builder.Services.AddScoped<IRegionRepository, RegionRepository>();
//here we are telling that whenever i asked for the IRegionRepository implementation give me the RegionRepository implementation

builder.Services.AddScoped<IWalkRepository, WalkRepository>();
//here we are telling that whenever i asked for the IWalkRepository implementation give me the WalkRepository implementation

builder.Services.AddSingleton<IUserRepository, StaticUserRepository>();
//Here we are using a static data, so we are using AddSingleton instead of Addscoped

builder.Services.AddScoped<ITokenHandler, NzWalks.API.Repository.TokenHandler>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])
        )
    });

var app = builder.Build();

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
