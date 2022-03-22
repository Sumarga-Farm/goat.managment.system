using CSharpFunctionalExtensions;
using GoatFarm.Management.Domain.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoatFarm.Management.Domain.MediaManagement
{
    public interface IPictureRepository : IRepository<Picture>
    {
        Picture Add(Picture picture);
        Task<Maybe<Picture>> GetByIdAsync(Guid pictureId);
    }
}
