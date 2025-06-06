using Mcparts.Infrastructure.Interfaces;
using Mcparts.Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Newtonsoft.Json;
using Npgsql;
using Swashbuckle;
using Swashbuckle.AspNetCore.Swagger;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("PostgreDB");
builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.Formatting = Formatting.Indented;
    });


builder.Services.AddSingleton((provider) => new NpgsqlConnection(connectionString));
builder.Services.AddSingleton<IDatabaseService, DatabaseService>();
builder.Services.AddSingleton<IItemCategorySevice, ItemCategorySevice>();
builder.Services.AddSingleton<IProductsSevice, ProductsSevice>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
