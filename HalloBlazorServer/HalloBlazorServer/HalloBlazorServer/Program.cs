using HalloBlazorServer.Data;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

Log.Logger = new LoggerConfiguration()
                    .WriteTo.File("log.txt", rollingInterval: RollingInterval.Month)
                    .WriteTo.ApplicationInsights(new TelemetryConfiguration("0b333280-ea27-4be6-b674-9a760934743a"), TelemetryConverter.Events)
                    .Enrich.WithProperty("App","Andres Blazor App")
                    .CreateLogger();

builder.Services.AddLogging(lb => lb.AddSerilog());

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
