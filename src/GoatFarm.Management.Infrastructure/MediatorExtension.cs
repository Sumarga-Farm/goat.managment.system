using Ardalis.GuardClauses;
using GoatFarm.Management.Domain.SharedKernel;
using GoatFarm.Management.Infrastructure;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace MediatR
{
    static class MediatorExtension
    {
        public static async Task DispatchDomainEventsAsync(this IMediator mediator, GoatFarmManagementDbContext dbContext)
        {
            IEnumerable<EntityEntry<IBaseEntity>> baseEntityEntries = GetBaseEntityEntiriesWithDomainEvents(dbContext);
            List<DomainEvent> domainEvents = GetDomainEventsFrom(baseEntityEntries);
            ClearDomainEventsFrom(baseEntityEntries);
            await PublishDomainEvents(mediator, domainEvents);
        }

        private static async Task PublishDomainEvents(IMediator mediator, IEnumerable<DomainEvent> domainEvents)
        {
            Guard.Against.Null(domainEvents, nameof(domainEvents));
            Guard.Against.Null(mediator, nameof(mediator));
            foreach (var domainEvent in domainEvents)
            {
                await mediator.Publish(domainEvent);
            }
        }

        private static void ClearDomainEventsFrom(IEnumerable<EntityEntry<IBaseEntity>> baseEntityEntries)
        {
            Guard.Against.Null(baseEntityEntries,nameof(baseEntityEntries));
            foreach (var baseEntityEntry in baseEntityEntries)
            {
                baseEntityEntry.Entity.ClearDomainEvents();
            }
        }

        private static List<DomainEvent> GetDomainEventsFrom(IEnumerable<EntityEntry<IBaseEntity>> baseEntityEntries)
        {
            Guard.Against.Null(baseEntityEntries, nameof(baseEntityEntries));
            return baseEntityEntries
                    .SelectMany(x => x.Entity.GetDomainEvents())
                    .ToList();
        }

        private static IEnumerable<EntityEntry<IBaseEntity>> GetBaseEntityEntiriesWithDomainEvents(GoatFarmManagementDbContext paymentDbContext)
        {
            Guard.Against.Null(paymentDbContext, nameof(paymentDbContext));
            return paymentDbContext.ChangeTracker
                            .Entries<IBaseEntity>()
                            .Where(x => x.Entity.HasAnyDomainEvents());
        }
    }
}
