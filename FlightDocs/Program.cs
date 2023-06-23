global using Microsoft.EntityFrameworkCore;
global using FlightDocs.Models;
global using FlightDocs.Data;
global using FlightDocs.Repository;
global using FlightDocs.Profiles;
using FlightDocs.Configrations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IDocTypesRepo, DocTypesRepo>();
builder.Services.AddScoped<IDocumentRepo, DocumentRepo>();
builder.Services.AddScoped<IFlightRepo, FlightRepo>();
builder.Services.AddScoped<IRoleRepo, RoleRepo>();
builder.Services.AddScoped<IPermissionRepo, PermissionRepo>();
builder.Services.AddScoped<IGroupPermissionRepo, GroupPermissionRepo>();

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(CustomProfile).Assembly);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException();
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));

builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("JwtConfig"));
builder.Services.AddAuthentication(options => 
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(jwt =>
{
    var key = Encoding.ASCII.GetBytes(builder.Configuration.GetSection("JwtConfig:SecretKey").Value!);
    jwt.SaveToken = true;
    jwt.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false,
        RequireExpirationTime = false,
        ValidateLifetime = true
    };
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
