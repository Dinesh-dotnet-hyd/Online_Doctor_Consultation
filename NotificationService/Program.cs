using Microsoft.AspNetCore.Cors.Infrastructure;
using NotificationService.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<INotificationService, NotificationService.Service.NotificationService>();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var MyCorsPolicy = "MyCorsPolicy";

builder.Services.AddCors(options =>
{
    options.AddPolicy(MyCorsPolicy, policy =>
    {
        policy
            .WithOrigins("http://localhost:5173")  // your frontend
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

builder.Services.AddControllers();


var app = builder.Build();
app.UseCors(MyCorsPolicy);   // <--- MUST be here before everything else

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
