using System.Reflection;

using api.Data;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApiContext>(options =>
                                              options.UseSqlite(builder.Configuration.GetConnectionString("apiContext")));

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(Mapper));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
    {
        var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
    });

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

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

/*
 *  182   │         // documentation generator
 183   │         services.AddSwaggerGen(c =>
 184   │         {
 185   │             c.SwaggerDoc("v1", new OpenApiInfo
 186   │             {
 187   │                 Title = this.appsettingOrEnv("Swagger:Title"), Version = this.appsettingOrEnv("Swagger:Version"),
 188   │             });
 189   │
 190   │             var securitySchema = new OpenApiSecurityScheme
 191   │             {
 192   │                 Description = "Using the Authorization header with the Bearer scheme.",
 193   │                 Name        = "Authorization",
 194   │                 In          = ParameterLocation.Header,
 195   │                 Type        = SecuritySchemeType.Http,
 196   │                 Scheme      = "bearer",
 197   │                 Reference = new OpenApiReference
 198   │                 {
 199   │                     Type = ReferenceType.SecurityScheme, Id = "Bearer",
 200   │                 },
 201   │             };
 202   │
 203   │             c.AddSecurityDefinition("Bearer", securitySchema);
 204   │
 205   │             c.AddSecurityRequirement(new OpenApiSecurityRequirement
 206   │             {
 207   │                 {
 208   │                     securitySchema, new[]
 209   │                     {
 210   │                         "Bearer",
 211   │                     }
 212   │                 },
 213   │             });
 214   │
 215   │
 216   │             // XML Documentation
 217   │             string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
 218   │             string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
 219   │             c.IncludeXmlComments(xmlPath);
 220   │
 221   │             c.EnableAnnotations();
 222   │             c.ExampleFilters();
 223   │
 224   │         });
 225   │         services.AddSwaggerExamplesFromAssemblies(Assembly.GetEntryAssembly()!);
 226   │     }

 */
