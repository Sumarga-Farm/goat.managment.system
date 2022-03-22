using MediatR;

namespace GoatFarm.Management.Domain.SharedKernel
{
    public abstract class DomainEvent : INotification
    {
        public DateTimeOffset OccurredAt { get; protected set; } = DateTimeOffset.UtcNow;
    }
}