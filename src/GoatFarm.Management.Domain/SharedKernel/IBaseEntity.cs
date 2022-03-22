using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoatFarm.Management.Domain.SharedKernel
{
    public interface IBaseEntity
    {
        IReadOnlyList<DomainEvent> GetDomainEvents();
        void ClearDomainEvents();
        bool HasAnyDomainEvents();
    }
}
