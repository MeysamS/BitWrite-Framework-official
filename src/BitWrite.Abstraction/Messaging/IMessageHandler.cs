using BitWrite.Abstraction.Messaging.Context;

namespace BitWrite.Abstraction.Messaging;

public interface IMessageHandler<in TMessage>
    where TMessage : class, IMessage
{
    Task HandleAsync(IConsumeContext<TMessage> messageContext, CancellationToken cancellationToken = default);

}