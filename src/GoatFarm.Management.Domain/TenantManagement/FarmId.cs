using CSharpFunctionalExtensions;

namespace GoatFarm.Management.Domain.TenantManagement
{
    public class FarmId : ValueObject
    {
        public static FarmId SumargaGoatFarmId = From(Guid.Parse("ada750ce-4167-4949-8ca8-f9f2834d40c3"));
        public Guid Value { get; set; }

        protected FarmId()
        {

        }
        protected FarmId(Guid goatId)
        {
            Value = goatId;
        }
        public static FarmId From(Guid goatId)
        {
            return new FarmId(goatId);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        internal static FarmId NewId()
        {
            return From(Guid.NewGuid());
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}