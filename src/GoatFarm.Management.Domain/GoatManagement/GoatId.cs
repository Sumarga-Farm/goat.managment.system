using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoatFarm.Management.Domain.GoatManagement
{
    public class GoatId : ValueObject
    {
        public Guid Value { get; set; }

        protected GoatId()
        {

        }
        protected GoatId(Guid goatId)
        {
            Value = goatId;
        }
        public static GoatId From(Guid goatId)
        {
            return new GoatId(goatId);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        internal static GoatId NewId()
        {
            return From(Guid.NewGuid());
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public static implicit operator Guid(GoatId goatId) => goatId.Value;
    }
}
