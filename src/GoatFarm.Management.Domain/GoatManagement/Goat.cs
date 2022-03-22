using Ardalis.GuardClauses;
using GoatFarm.Management.Domain.MediaManagement;
using GoatFarm.Management.Domain.SharedKernel;
using GoatFarm.Management.Domain.TenantManagement;

namespace GoatFarm.Management.Domain.GoatManagement
{
    public class Goat : BaseEntity<GoatId>, IAggregateRoot
    {
        public string Name { get; private set; }
        public Gender Gender { get; private set; }
        public string IdentityDescription { get; private set; }
        public PictureId PictureId { get; private set; }

        public DateTimeOffset DateOfBirth { get; private set; }
        public GoatAvailableStatus AvailableStatus { get; private set;}
        public TagNumber TagNumber { get; private set; }
        public DateTimeOffset DateAddedUTC { get; private set; } = DateTimeOffset.UtcNow;

        public FarmId FarmId { get; private set; }

        protected Goat()
        {

        }
        protected Goat(string name,  Gender gender, string identityDescription, 
                       PictureId pictureId, TagNumber tagNumber, DateTimeOffset dateOfBirth,
                       FarmId farmId)
        {
            Id = GoatId.NewId();
            Name = name;
            TagNumber = tagNumber;
            Gender = gender;
            IdentityDescription = identityDescription;
            PictureId = pictureId;
            DateOfBirth = dateOfBirth;
            AvailableStatus = GoatAvailableStatus.AtFarm;
            FarmId = farmId;
        }

        public static Goat NewFrom(string name, Gender gender, string identityDescription, 
                                   PictureId pictureId, TagNumber tagNumber, DateTimeOffset dateOfBirth,
                                   FarmId farmId)
        {
            Guard.Against.NullOrEmpty(name, nameof(name));
            Guard.Against.NullOrEmpty(identityDescription, nameof(identityDescription));
            Guard.Against.Null(pictureId, nameof(pictureId));
            Guard.Against.Null(tagNumber, nameof(tagNumber));
            var newGoat = new Goat(name, gender, identityDescription, pictureId, tagNumber, dateOfBirth, farmId);
            newGoat.AddDomainEvent(NewGoatAddedDomainEvent.From(newGoat));
            return newGoat;
        }
    }
}
