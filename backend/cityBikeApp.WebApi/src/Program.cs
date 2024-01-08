using cityBikeApp.Business.src.Services.Abstractions;
using cityBikeApp.Business.src.Services.Implementations;
using cityBikeApp.Domain.src.Abstractions;
using cityBikeApp.WebApi.src.Database;
using cityBikeApp.WebApi.src.RepoImplementations;
using Microsoft.EntityFrameworkCore;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

var npgsqlBuilder = new NpgsqlConnectionStringBuilder(connectionString);
var dataSource = npgsqlBuilder.ConnectionString;

builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseNpgsql(dataSource)
           .UseSnakeCaseNamingConvention();
});

builder.Services
    .AddScoped<IStationRepo, StationRepo>()
    .AddScoped<IJourneyRepo, JourneyRepo>()
    .AddScoped<IStationService, StationService>()
    .AddScoped<IJourneyService, JourneyService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();


