using Hangfire;
using Hangfire.SqlServer;
using Microsoft.EntityFrameworkCore;
using ProductFeederCoreLib.Data;
using ProductFeederCoreLib.Services;
using ProductFeederRESTfulAPI.Mapper;

var builder = WebApplication.CreateBuilder(args);
string connectionString = builder.Configuration.GetConnectionString("LocalDb");

// Add services to the container.
builder.Services.AddDbContext<FeederProductsDbContext>(options=> options.UseSqlServer(connectionString,sqlProp=> sqlProp.MigrationsAssembly("ProductFeederCoreLib")));

//hangfire configuration
builder.Services.AddHangfire(configuration => configuration
    .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
    .UseSimpleAssemblyNameTypeSerializer()
    .UseRecommendedSerializerSettings()
    .UseSqlServerStorage(connectionString,
        new SqlServerStorageOptions()
        {
            CommandBatchMaxTimeout= TimeSpan.FromMinutes(5),
            SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
            QueuePollInterval = TimeSpan.Zero,
            UseRecommendedIsolationLevel = true,
            DisableGlobalLocks = true,
        }
    )
);

builder.Services.AddHangfireServer();

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

//hangfire dashboard
app.UseHangfireDashboard();

app.MapControllers();

app.Run();

public partial class Program{ }
