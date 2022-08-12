using Microsoft.EntityFrameworkCore;
using ProductFeederCoreLib.Data;
using ProductFeederCoreLib.Services;
using ProductFeederRESTfulAPI.Mapper;

var builder = WebApplication.CreateBuilder(args);
string connectionString = builder.Configuration.GetConnectionString("LocalDb");

// Add services to the container.
builder.Services.AddDbContext<FeederProductsDbContext>(options=> options.UseSqlServer(connectionString,sqlProp=> sqlProp.MigrationsAssembly("ProductFeederCoreLib")));
builder.Services.AddAutoMapper(typeof(AutoMapperConfig).Assembly);
ServicesInjector.InjectServices(builder.Services);

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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

public partial class Program{ }
