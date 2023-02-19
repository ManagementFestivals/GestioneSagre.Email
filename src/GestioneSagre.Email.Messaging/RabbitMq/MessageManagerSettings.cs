using System.Text.Json;
using GestioneSagre.Email.Messaging.Abstractions;

namespace GestioneSagre.Email.Messaging.RabbitMq;

public class MessageManagerSettings
{
    public string ConnectionString { get; set; }
    public string ExchangeName { get; set; }
    public ushort QueuePrefetchCount { get; set; }
    public JsonSerializerOptions JsonSerializerOptions { get; set; } = JsonOptions.Default;
}