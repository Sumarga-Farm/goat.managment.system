using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoatFarm.Management.Domain.SharedKernel
{
    public interface IRepository<TAggregateRoot> where TAggregateRoot: IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
