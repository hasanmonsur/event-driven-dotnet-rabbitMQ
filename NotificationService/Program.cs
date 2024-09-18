using NotificationService.Handlers;
using SharedLibrary.EventModels;
using SharedLibrary.Messaging;
using System.Reflection.Metadata;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add RabbitMQ services here
builder.Services.AddSingleton<PaymentProcessedEventHandler>();
builder.Services.AddSingleton<IEventBus, RabbitMQEventBus>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


var eventBus = app.Services.GetRequiredService<IEventBus>();
//eventBus.Subscribe<PaymentProcessedEvent>("PaymentProcessedQueue", HandlePaymentProcessedEvent);
var processedEventHandler = app.Services.GetRequiredService<PaymentProcessedEventHandler>();

eventBus.Subscribe<PaymentProcessedEvent>("PaymentProcessedQueue", processedEventHandler.Handle);

app.Run();

//void HandlePaymentProcessedEvent(PaymentProcessedEvent paymentEvent)
//{
//    if (paymentEvent.PaymentSuccess)
//    {
//        Console.WriteLine($"Sending notification: Payment successful for Ticket ID: {paymentEvent.TicketId}");
//    }
//}