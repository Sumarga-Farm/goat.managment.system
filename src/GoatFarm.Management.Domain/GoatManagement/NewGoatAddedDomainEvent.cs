using Ardalis.GuardClauses;
using GoatFarm.Management.Domain.SharedKernel;

namespace GoatFarm.Management.Domain.GoatManagement
{
    public class NewGoatAddedDomainEvent : DomainEvent
    {
        public Goat Goat { get; private set; }

        public NewGoatAddedDomainEvent(Goat goat)
        {
            Goat = goat;
        }

        internal static NewGoatAddedDomainEvent From(Goat newGoat)
        {
            Guard.Against.Null(newGoat, nameof(newGoat));
            return new NewGoatAddedDomainEvent(newGoat);
        }
    }
}