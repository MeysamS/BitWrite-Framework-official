namespace BitWrite.Abstraction.Messaging;

[Flags]
public enum MessageDeliveryType
{
    Outbox = 1,
    Inbox = 2,
    Internal = 4
}