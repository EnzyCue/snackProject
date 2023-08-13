using Api.Application.Snack;
using Api.Application.Snack.Interfaces;
using Api.Application.Snack.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IStoreService, ColesService>();
builder.Services.AddScoped<IStoreService, WoolworthsService>();
builder.Services.AddSingleton<CacheService>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(SnackApiEntry).Assembly));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseCors(config => config
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowAnyOrigin());
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();