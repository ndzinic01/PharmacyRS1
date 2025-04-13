using Microsoft.EntityFrameworkCore;
using NewPharmacy.Data;
using NewPharmacy.Helper.Auth;
using NewPharmacy.Services;
using NewPharmacy.Helper; // ako AzureStorageOptions ide ovdje
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Dodaj konfiguraciju iz appsettings.json (ovo već Builder sam radi)
var configuration = builder.Configuration;

// Konfiguracija konekcije za bazu
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("db1")));

// Registracija konfiguracije za Azure Storage
builder.Services.Configure<AzureStorageOptions>(
    configuration.GetSection("AzureStorage"));

// Dodavanje servisa
builder.Services.AddScoped<ProductService>();
builder.Services.AddTransient<MyAuthService>();
builder.Services.AddScoped<AzureBlobService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x => x.OperationFilter<MyAuthorizationSwaggerHeader>());
builder.Services.AddHttpContextAccessor();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        builder => builder.WithOrigins("http://localhost:4200")
        .AllowAnyMethod()
        .AllowAnyHeader());
});

var app = builder.Build();

// Middleware
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.UseCors("AllowAngularApp");

app.MapControllers();

app.Run();

