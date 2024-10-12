using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Server.Data;
using Shared.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme()
    {
        In = ParameterLocation.Header,
        Name = "Authurization",
        Type = SecuritySchemeType.ApiKey
    }));

// all service registeration


// connection strting 
var connectionString = builder.Configuration.GetConnectionString("DefaultConnectionString");
if (connectionString == null)
    throw new Exception("Invalid connections strinig");
builder.Services.AddDbContext<AcademicProjectDbContext>(
    options =>
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// boilerplate identity  stuff 
builder.Services.AddAuthorization();
builder.Services.AddIdentityApiEndpoints<ApplicationUser>().AddEntityFrameworkStores<AcademicProjectDbContext>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapIdentityApi<ApplicationUser>();

app.UseAuthorization();

app.MapControllers();

app.Run();