namespace GestioneSagre.Email.Messaging.Abstractions;

public interface IMessageReceiver<T> where T : class
{
    Task ReceiveAsync(T message, CancellationToken cancellationToken);
}