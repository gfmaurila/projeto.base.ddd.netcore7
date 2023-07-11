using AutoMapper;
using IOC;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
Config.ConfigDbContext(builder.Services, builder.Configuration);
Config.ConfigRepository(builder.Services);
Config.ConfigService(builder.Services);

builder.Services.AddHttpClient();
Config.ConfigBusService(builder.Services);

builder.Services.AddSingleton(
    new MapperConfiguration(cfg =>
    {
        cfg.AddProfile(new MappingProfile());
    }).CreateMapper());


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Projeto DDD .NET Core 7",
        Version = "v1",
        Description = "Projeto DDD .NET Core 7",
        Contact = new OpenApiContact
        {
            Name = "Guilherme F Maurila",
            Email = "gfmaurila@gmail.com",
            Url = new Uri("https://github.com/gfmaurila"),
        }
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});


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


app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Projeto DDD .NET Core 7");
    c.RoutePrefix = string.Empty;
});
app.Run();
