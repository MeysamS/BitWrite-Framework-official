using BitWrite.Abstraction.Messaging.Context;

namespace BitWrite.Abstraction.Messaging;

public delegate Task MessageHandler<in TMessage>(
    IConsumeContext<TMessage> context,
    CancellationToken cancellationToken = default
) where TMessage : class, IMessage;

public delegate Task<Acknowledgement> MessageHandlerAck<in TMessage>(
    IConsumeContext<TMessage> context,
    CancellationToken cancellationToken = default
)
    where TMessage : class, IMessage;
