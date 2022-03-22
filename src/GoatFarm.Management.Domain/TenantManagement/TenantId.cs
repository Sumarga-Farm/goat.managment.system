using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoatFarm.Management.Domain.TenantManagement
{
    public class TenantId : ValueObject
    {
        public static TenantId SumargaGoatFarmTenantId = From(Guid.Parse("ada750ce-4167-4949-8ca8-f9f2834d40c3"));
        
        public Guid Value { get; set; }

        protected TenantId()
        {

        }
        protected TenantId(Guid pictureId)
        {
            Value = pictureId;
        }
        public static TenantId From(Guid tenantId)
        {
            return new TenantId(tenantId);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
