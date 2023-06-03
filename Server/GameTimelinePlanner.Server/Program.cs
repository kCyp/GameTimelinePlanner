using GameTimelinePlanner.Infrastructure.Repository;
using GameTimelinePlanner.Shared.Domain.Entity;
using GameTimePlanner.Application.Interface;
using GameTimePlanner.Application.Service;
using Microsoft.Extensions.Logging.Console;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddTransient<IRepository<Job>, JsonRepository<Job>>();
builder.Services.AddTransient<IRepository<Duty>, JsonRepository<Duty>>();
builder.Services.AddTransient<JsonContext, JsonContext>();
builder.Services.AddTransient<IGameService, GameService>();

builder.Services.AddLogging((o) =>
{
    o.SetMinimumLevel(LogLevel.Information);
    o.AddConsole();
    o.SetMinimumLevel(LogLevel.Trace);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
