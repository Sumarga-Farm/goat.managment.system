using CSharpFunctionalExtensions;
using GoatFarm.Management.Domain.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoatFarm.Management.Domain.GoatManagement
{
    public interface ITagRepository : IRepository<Tag>
    {
        Task<Maybe<Tag>> GetAsync(TenantManagement.FarmId sumargaGoatFarmId, string tagNumber);
        Task<IEnumerable<Tag>> GetAvailableTagsAsync(TenantManagement.FarmId sumargaGoatFarmId);
    }
}
