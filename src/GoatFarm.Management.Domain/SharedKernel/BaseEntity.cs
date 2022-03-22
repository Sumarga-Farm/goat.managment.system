using CSharpFunctionalExtensions;

namespace GoatFarm.Management.Domain.SharedKernel
{
    public abstract class BaseEntity<TId> : Entity<TId>, IBaseEntity
    {
        private readonly List<DomainEvent> _domainEvents = new();

        public virtual IReadOnlyList<DomainEvent> GetDomainEvents() => _domainEvents.AsReadOnly();

        protected void AddDomainEvent(DomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }
        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }

        public bool HasAnyDomainEvents()
        {
            return _domainEvents.Any();
        }
    }
}
