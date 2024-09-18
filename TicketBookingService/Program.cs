using Microsoft.OpenApi.Models;
using SharedLibrary.Messaging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Add RabbitMQ services here

builder.Services.AddSingleton<IEventBus, RabbitMQEventBus>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ticket Booking Service", Version = "v1" });
});


var app = builder.Build();

// Enable Swagger middleware
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ticket Booking Service v1");
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
