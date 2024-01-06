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

// builder.Services.AddScoped<DatabaseContext>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

var npgsqlBuilder = new NpgsqlDataSourceBuilder(connectionString);

var dataSource = npgsqlBuilder.Build();

// builder.Services.AddDbContext<DatabaseContext>(options =>
// {
//     options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
// });


builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseNpgsql(dataSource)
           .UseSnakeCaseNamingConvention();
});

builder.Services
.AddScoped<IStationRepo, StationRepo>()
.AddScoped<IStationService, StationService>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// var npgsqlBuilder = new NpgsqlDataSourceBuilder(connectionString);

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

