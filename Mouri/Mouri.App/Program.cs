using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Mouri.App.Services;
using Mouri.Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
//builder.Services.AddSingleton<WeatherForecastService>();

// Added Dependency Injection for the Code Analysis service
builder.Services.AddSingleton<ICodeAnalysis, CodeAnalysis>();
builder.Services.AddHttpClient<ICodeAnalysis, CodeAnalysis>(client => {client.BaseAddress 
    = new Uri("https://localhost:7110/");
});
builder.Services.AddSingleton<PatientService>();
builder.Services.AddHttpClient<IPatient, PatientService>(client =>
{
    client.BaseAddress
    = new Uri("https://localhost:7110/");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
