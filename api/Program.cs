using System.Data.Common;
using System.Reflection;

using api.Data;
using api.Utils;

using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

switch (Misc.AppSettingOrEnv(builder.Configuration, "Database:Type", "postgres"))
{

    case "sqlite":
        builder.Services.AddDbContext<ApiContext>(options =>
                                                      options.UseSqlite(builder.Configuration.GetConnectionString("apiContext"))
        );
        break;
    case "postgres":
    default:
        var cb = new DbConnectionStringBuilder
        {
            {
                "Username", Misc.AppSettingOrEnv(builder.Configuration, "Database:Username")
            },
            {
                "Password", Misc.AppSettingOrEnv(builder.Configuration, "Database:Password")
            },
            {
                "Host", Misc.AppSettingOrEnv(builder.Configuration, "Database:Host")
            },
            {
                "Port", Misc.AppSettingOrEnv(builder.Configuration, "Database:Port")
            },
            {
                "Database", Misc.AppSettingOrEnv(builder.Configuration, "Database:Database")
            },
            {
                "SSL Mode", Misc.AppSettingOrEnv(builder.Configuration, "Database:SslMode", "Prefer")
            },
            {
                "Trust Server Certificate", true
            },
            {
                "Include Error Detail", true
            },
        };
        builder.Services.AddDbContext<ApiContext>(options =>
                                                      options.UseNpgsql(cb.ConnectionString)
        );
        break;
}

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(cfg => cfg.AddMaps(typeof(Mapper).Assembly));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
    {
        var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
        c.SwaggerDoc("v1alpha1", new OpenApiInfo
        {
            Title   = "PF1e API",
            Version = "v1alpha1",
        });
    });

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
app.UseSwagger();
app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1alpha1/swagger.json", "v1alpha1");
        options.RoutePrefix = string.Empty;
    });
// }

// app.UseHttpsRedirection(); // this is handled by the reverse proxy

app.UseAuthorization();

app.MapControllers();

app.Run();
