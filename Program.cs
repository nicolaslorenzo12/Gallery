using LensLogic.data;
using LensLogic.repository;
using LensLogic.Service;
using LensLogic.Service.PhotoPricingService;
using LensLogic.Service.PhotoService;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<PhotoDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "LensLogic API", Version = "v1" });
});

builder.Services.AddTransient<IPhotoRepository, PhotoRepository>();
builder.Services.AddScoped<IPhotoService, PhotoService>();
builder.Services.AddSingleton<PhotoPricingCalculator>();

builder.Services.AddSingleton<IPhotoPriceStrategy, AttemptPriceStrategy>();
builder.Services.AddSingleton<IPhotoPriceStrategy, EventPriceStrategy>();
builder.Services.AddSingleton<IPhotoPriceStrategy, ExperiencePriceStrategy>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "LensLogic API v1");
    });
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
