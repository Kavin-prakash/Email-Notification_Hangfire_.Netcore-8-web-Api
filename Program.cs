using Hangfire_EmailNotification.Context;
using Microsoft.EntityFrameworkCore;
using Hangfire;
using Hangfire.MySql;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add MySql Database connectivity
var connectionstring = builder.Configuration.GetConnectionString("MySqlDatabaseConnection");

builder.Services.AddDbContext<HangfileContext>(options => options.UseMySql(connectionstring,
new MySqlServerVersion(new Version())));


// Hangfire Implementation in Main Method
builder.Services.AddHangfire((param1, param2) =>
{
    var hangfireconnectionstring = param1.GetRequiredService<IConfiguration>().GetConnectionString("HangfireDatabaseConnection");

    var storageoptions = new MySqlStorageOptions()
    {

    };
    param2.UseStorage(new MySqlStorage(hangfireconnectionstring, storageoptions));
});

// Add the Hangfire Server ()
#region
builder.Services.AddHangfireServer();
#endregion

// Service Registration
builder.Services.AddScoped<IUserRegistrationService,UserRegistrationService>();
builder.Services.AddScoped<HangfileContext>();



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

// Add Hangfire for Background Email Sending process

RecurringJob.AddOrUpdate<GetAllSubscribedUsers>(x => x.GetAllSubscribed(), "0 * * * *");
app.Run();
