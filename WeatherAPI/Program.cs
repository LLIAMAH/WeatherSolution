using Microsoft.EntityFrameworkCore;
using WeatherAPI.Configs;
using WeatherAPI.DB;
using WeatherAPI.DB.Reps;
using WeatherAPI.DB.Reps.Interfaces;
using WeatherAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbCtx>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddControllers();
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var corsData = builder.Configuration.GetSection("CORS")?.Get<Cors>();
// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(corsData?.Name ?? Cors.NameDefault,
        corsBuilder => corsBuilder
            .WithOrigins(corsData?.WebAddresses ?? Cors.WebAddressesDefault)
            .AllowAnyMethod()
            .AllowAnyHeader());
});

var app = builder.Build();

app.UseCors(corsData?.Name ?? Cors.NameDefault);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseRouting();
app.UseMiddleware<RequestLoggingMiddleware>();

app.MapControllers();

app.Run();
