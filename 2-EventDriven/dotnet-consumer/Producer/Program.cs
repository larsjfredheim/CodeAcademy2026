using CodeAcademy.DotnetConsumer.Common.Config;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

Console.WriteLine("Producer starting...");
// Establish connection to RabbitMQ
using var connection = await ConnectionHelper.ConnectAsync();
Console.WriteLine("Connected to RabbitMQ");

/*
#region Queue
// Create a channel and declare the queue
using var channel = await connection.CreateChannelAsync();
await channel.QueueDeclareAsync(
    queue: "idem-events",
    durable: true,
    exclusive: false,
    autoDelete: false,
    arguments: null);

// Publish messages to the queue with for loop to simulate multiple events
for (int i = 0; i < 10; i++)
{
    var message = $"Idems Event {i + 1} at {DateTime.Now}";

    var messageBody = JsonSerializer.Serialize(message);
    var body = Encoding.UTF8.GetBytes(messageBody);

    await channel.BasicPublishAsync(
        exchange: string.Empty,
        routingKey: "idem-events",
        mandatory: true,
        basicProperties: new BasicProperties{ Persistent = true }, body: body);
    Console.WriteLine($"Published event: {message}");

    await Task.Delay(2000);
}
#endregion
*/

/*
#region Fanout
using var fanoutChannel = await connection.CreateChannelAsync();
await fanoutChannel.ExchangeDeclareAsync(
    exchange: "fanout-exchange",
    type: ExchangeType.Fanout,
    durable: true,
    autoDelete: false,
    arguments: null);

// Publish messages to the fanout exchange with for loop to simulate multiple events
for (int i = 0; i < 10; i++)
{
    var message = $"Idems Event {i + 1} at {DateTime.Now} (fanout)";

    var messageBody = JsonSerializer.Serialize(message);
    var body = Encoding.UTF8.GetBytes(messageBody);

    await fanoutChannel.BasicPublishAsync(
        exchange: "fanout-exchange",
        routingKey: string.Empty,
        mandatory: false,
        basicProperties: new BasicProperties{ Persistent = true }, body: body);
    Console.WriteLine($"Published event: {message}");

    await Task.Delay(2000);
}
#endregion
*/

/*
#region Direct
using var fanoutChannel = await connection.CreateChannelAsync();
await fanoutChannel.ExchangeDeclareAsync(
    exchange: "direct-exchange",
    type: ExchangeType.Direct,
    durable: true,
    autoDelete: false,
    arguments: null);

// Publish messages to the fanout exchange with for loop to simulate multiple events
for (int i = 0; i < 10; i++)
{
    var message = $"Idems Event {i + 1} at {DateTime.Now} (direct via routing key)";

    var messageBody = JsonSerializer.Serialize(message);
    var body = Encoding.UTF8.GetBytes(messageBody);

    await fanoutChannel.BasicPublishAsync(
        exchange: "direct-exchange",
        routingKey: "RK1",
        mandatory: false,
        basicProperties: new BasicProperties{ Persistent = true }, body: body);
    Console.WriteLine($"Published event: {message}");

    await Task.Delay(2000);
}
#endregion
*/

#region Topic
using var fanoutChannel = await connection.CreateChannelAsync();
await fanoutChannel.ExchangeDeclareAsync(
    exchange: "topic-exchange",
    type: ExchangeType.Topic,
    durable: true,
    autoDelete: false,
    arguments: null);

// Publish messages to the fanout exchange with for loop to simulate multiple events
for (int i = 0; i < 10; i++)
{
    var message = $"Idems Event {i + 1} at {DateTime.Now} (topic)";

    var messageBody = JsonSerializer.Serialize(message);
    var body = Encoding.UTF8.GetBytes(messageBody);

    await fanoutChannel.BasicPublishAsync(
        exchange: "topic-exchange",
        routingKey: "RK1",
        mandatory: false,
        basicProperties: new BasicProperties{ Persistent = true }, body: body);
    Console.WriteLine($"Published event: {message}");

    await Task.Delay(2000);
}
#endregion

Console.WriteLine("Producer finished.");