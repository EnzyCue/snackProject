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

var corsPolicy = builder.Configuration["CorsPolicy"];

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: corsPolicy,
                      b =>
                      {
                          b.WithOrigins(builder.Configuration["Frontend:Host"]).AllowAnyHeader();
                      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(corsPolicy);

app.UseAuthorization();

app.MapControllers();

app.Run();