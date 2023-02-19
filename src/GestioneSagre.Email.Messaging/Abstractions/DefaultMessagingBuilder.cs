using Microsoft.Extensions.DependencyInjection;

namespace GestioneSagre.Email.Messaging.Abstractions;

internal class DefaultMessagingBuilder : IMessagingBuilder
{
    public IServiceCollection Services { get; }

    public DefaultMessagingBuilder(IServiceCollection services)
    {
        Services = services;
    }
}