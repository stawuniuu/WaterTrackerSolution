using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using WaterConsumptionTracker.Data;
using WaterTracker.API.Repositories;
using WaterTracker.API.Repositories.Contracts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContextPool<WaterTrackerDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WaterTrackerConnection"))
    );

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IWaterRepository, WaterRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(policy =>
    policy.WithOrigins("http://localhost:7096", "https://localhost:7096")
    .AllowAnyMethod()
    .WithHeaders(HeaderNames.ContentType)
);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
