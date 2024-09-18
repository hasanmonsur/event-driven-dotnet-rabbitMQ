using PaymentService.Handlers;
using SharedLibrary.EventModels;
using SharedLibrary.Messaging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add RabbitMQ services here
builder.Services.AddSingleton<TicketPurchasedEventHandler>();
builder.Services.AddSingleton<IEventBus, RabbitMQEventBus>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var eventBus = app.Services.GetRequiredService<IEventBus>();
//eventBus.Subscribe<TicketPurchasedEvent>("TicketPurchasedQueue", HandleTicketPurchasedEvent);
var ticketEventHandler = app.Services.GetRequiredService<TicketPurchasedEventHandler>();
eventBus.Subscribe<TicketPurchasedEvent>("TicketPurchasedQueue", ticketEventHandler.Handle);

app.Run();

