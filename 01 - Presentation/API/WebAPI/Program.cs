
using AutoMapper;
using IOC;

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
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();

app.Run();
