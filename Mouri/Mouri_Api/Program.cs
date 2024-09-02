using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Mouri.Shared;

using Mouri_Api.JWT;
using Mouri_Api.MiddleWare;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Depdency injection patient service
builder.Services.AddSingleton<IPatientData, PatientDataService>();
// Depdency injection patient service
builder.Services.AddSingleton<IPatientData, PatientDataService>();
//Depdency injection Userservice service
builder.Services.AddScoped<IUserService, UserService>();
// Register expection middle ware Transien
builder.Services.AddTransient<GlobalExceptionHandlingMiddleware>();
var jwtToken= builder.Configuration["Jwt:Key"];
//Authenticatio,
builder.Services.AddAuthentication(x=>
{

    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {       
         ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtToken)),
        ValidateAudience = false,
        ValidateIssuer = false
    };
    builder.Services.AddAuthentication();
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//Authetication and Authentication
app.UseAuthentication();
app.UseAuthorization();
// Handle Globally Exception Handling
app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();
