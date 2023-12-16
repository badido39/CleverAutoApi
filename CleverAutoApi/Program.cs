using CleverAutoApi.Data;
using CleverAutoApi.Services;
using CleverAutoApi.SignalR;
using Hangfire;
using Microsoft.EntityFrameworkCore;
using SignalRWebApi.Services;
var builder = WebApplication.CreateBuilder(args);

SQLitePCL.Batteries.Init();

builder.Services.AddControllers();

builder.Services.AddScoped<CheckServiceJob>();
builder.Services.AddScoped<CustomerService>();

builder.Services.AddSignalR();



builder.Services.AddHangfire(configuration =>
{    
    GlobalConfiguration.Configuration.UseInMemoryStorage();
});

builder.Services.AddHangfireServer(); // Add Hangfire server

builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlite("Data Source=AppDatabase.db"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<INotificationService, NotificationService>();


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
    recurringJobManager.AddOrUpdate("daily-service-check", () => job.CheckService(), "*/30 * * * * *");

    //With this modification, the job will run daily at 8:00 AM.

    //recurringJobManager.AddOrUpdate("daily-service-check", () => job.CheckService(), "0 0 8 * * *");

}
app.MapHub<NotificationHub>("/hub");
app.Run();

