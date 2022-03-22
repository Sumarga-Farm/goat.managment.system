using CSharpFunctionalExtensions;

namespace GoatFarm.Management.Domain.GoatManagement
{
    public class TagId : ValueObject
    {
        public Guid Value { get; set; }

        protected TagId()
        {

        }
        protected TagId(Guid tagId)
        {
            Value = tagId;
        }
        public static TagId From(Guid tagId)
        {
            return new TagId(tagId);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        internal static TagId NewId()
        {
            return From(Guid.NewGuid());
        }


        public override string ToString()
        {
            return Value.ToString();
        }

        public static implicit operator string(TagId tagId) => tagId.ToString();
    }
}
