using Mcparts.Business.Mappings;
using Mcparts.Business.Services;
using Mcparts.Business.Services.IServices;
using Mcparts.Business.Services.IServices.IServiceMappings;
using Mcparts.Business.Services.Services;
using Mcparts.DataAccess.Interfaces;
using Mcparts.DataAccess.Models;
using Mcparts.DataAccess.Repositories;
using Mcparts.Infrastructure.Interfaces;
using Mcparts.Infrastructure.Services;
using McPartsAPI.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Npgsql;
using Swashbuckle;
using Swashbuckle.AspNetCore.Swagger;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(SwaggerConfiguration.Configure);
var connectionString = builder.Configuration.GetConnectionString("PostgreDB");
builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.Formatting = Formatting.Indented;
    });


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
});

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
//builder.Services.AddScoped<McpartsDbContext>();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));


builder.Services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
builder.Services.AddScoped(typeof(IReadServiceAsync<,>), typeof(ReadServiceAsync<,>));
builder.Services.AddScoped(typeof(IGenericServiceAsync<,>), typeof(GenericServiceAsync<,>));

builder.Services.AddScoped((provider) => new NpgsqlConnection(connectionString));
//builder.Services.AddScoped<IDatabaseService, DatabaseService>();
//builder.Services.AddScoped<IItemCategorySevice, ItemCategorySevice>();
//builder.Services.AddScoped<IProductsSevice, ProductsSevice>();
builder.Services.AddScoped<IProductGroupService, ProductGroupService>();
builder.Services.AddScoped<IProductCategoryService, ProductCategoryService>();
builder.Services.AddScoped<IProductMetadataService, ProductMetadataService>();
builder.Services.AddScoped<IProductMetadataValuesService, ProductMetadataValuesService>();
builder.Services.AddScoped<IProductSubCategoryService, ProductSubCategoryService>();
builder.Services.AddScoped<IProductSubCategorySubsetService, ProductSubCategorySubsetService>();
builder.Services.AddScoped<IProductsService, ProductsService>();
builder.Services.AddScoped<IProductsGetSevice, ProductsGetSevice>();
builder.Services.AddScoped<IProductMapperService, ProductMapperService>();
builder.Services.AddScoped<ICustomersService, CustomersService>();
builder.Services.AddScoped<IUsersService, UsersService>();


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var key = builder.Configuration.GetValue<string>("Jwt:Key");

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                        ValidIssuer = builder.Configuration.GetValue<string>("Jwt:Issuer"),
                        ValidAudience = builder.Configuration.GetValue<string>("Jwt:Audience"),
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero,
                    };
                });

builder.Services.AddAuthorization();

//var connectionString = builder.Configuration.GetConnectionString("PostgreDB");
builder.Services.AddEntityFrameworkNpgsql().AddDbContext<McpartsDbContext>(options =>
options.UseNpgsql(connectionString));

System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
