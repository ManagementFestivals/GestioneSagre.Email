using Microsoft.Extensions.DependencyInjection;

namespace GestioneSagre.Email.Messaging.Abstractions;

public interface IMessagingBuilder
{
    IServiceCollection Services { get; }
}