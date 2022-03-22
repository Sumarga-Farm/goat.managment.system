using CSharpFunctionalExtensions;
using GoatFarm.Management.Domain.TenantManagement;

namespace GoatFarm.Management.Domain.GoatManagement
{
    public class TagNumber : ValueObject
    {
        public string Value { get; set; }

        protected TagNumber()
        {

        }

        public static TagNumber From(string tagNumber)
        {
            return new TagNumber { Value = tagNumber };
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public override string ToString()
        {
            return Value;
        }

        public static implicit operator string(TagNumber tagNumber) => tagNumber.ToString();
    }
}