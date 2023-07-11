using AutoMapper;
using IOC;
using WebAPI.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
Config.ConfigDbContext(builder.Services, builder.Configuration);
Config.ConfigRepository(builder.Services);
Config.ConfigService(builder.Services);
Config.ConfigValidator(builder.Services);

builder.Services.AddHttpClient();
Config.ConfigBusService(builder.Services);

builder.Services.AddSingleton(
    new MapperConfiguration(cfg =>
    {
        cfg.AddProfile(new MappingProfile());
    }).CreateMapper());


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfiguration(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

if (app.Environment.IsDevelopment() || app.Environment.IsEnvironment("Docker") || app.Environment.IsStaging())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();
