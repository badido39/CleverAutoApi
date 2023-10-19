using CleverAutoApi.Data;
using CleverAutoApi.Services;
using Hangfire;
using Hangfire.SQLite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
var builder = WebApplication.CreateBuilder(args);

SQLitePCL.Batteries.Init();

builder.Services.AddControllers();

builder.Services.AddScoped<CheckServiceJob>();
builder.Services.AddHangfire(configuration =>
{
    string connectionString = "Data Source=hangfire.db;"; // Modify the connection string as needed
    GlobalConfiguration.Configuration.UseSQLiteStorage(connectionString);
});

builder.Services.AddHangfireServer(); // Add Hangfire server

builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlite("Data Source=AppDatabase.db"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.UseHangfireDashboard();

using (var scope = app.Services.CreateScope())
{
    var job = scope.ServiceProvider.GetRequiredService<CheckServiceJob>();
    var recurringJobManager = app.Services.GetRequiredService<IRecurringJobManager>();
    recurringJobManager.AddOrUpdate("daily-service-check", () => job.CheckService(), Cron.Daily);
}
app.Run();

