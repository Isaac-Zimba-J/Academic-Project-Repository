using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Server.Data;
using Server.Services;
using Shared.Models;
using Shared.Services.Contracts;
using Shared.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient();

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme()
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    }));
builder.Services.AddAutoMapper(typeof(Program));

// all service registration
builder.Services.AddScoped<IApplicationUserService, ApplicationUserService>();
builder.Services.AddScoped<IProjectGroupService, ProjectGroupService>();
builder.Services.AddScoped<IProjectReportService, ProjectReportService>();
builder.Services.AddScoped<IProjectContributorService, ProjectContributorService>();
builder.Services.AddScoped<UploadService>();




// connection strting 
var connectionString = builder.Configuration.GetConnectionString("DefaultConnectionString");
if (connectionString == null)
    throw new Exception("Invalid connections string");
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
app.UseStaticFiles();
app.UseAuthorization();

app.MapControllers();

app.Run();