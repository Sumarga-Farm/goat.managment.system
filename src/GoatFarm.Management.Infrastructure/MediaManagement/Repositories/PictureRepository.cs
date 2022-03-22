using CSharpFunctionalExtensions;
using GoatFarm.Management.Domain.MediaManagement;
using GoatFarm.Management.Domain.SharedKernel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoatFarm.Management.Infrastructure.MediaManagement.Repositories
{
    public class PictureRepository : IPictureRepository
    {
        private readonly GoatFarmManagementDbContext _dbContext;

        public IUnitOfWork UnitOfWork => _dbContext;

        public PictureRepository(GoatFarmManagementDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public Picture Add(Picture picture)
        {
            return _dbContext.Pictures.Add(picture).Entity;
        }

        public async Task<Maybe<Picture>> GetByIdAsync(Guid pictureId)
        {
            Picture? picture = await _dbContext.Pictures
                                .FirstOrDefaultAsync(picture=> picture.Id == PictureId.From(pictureId));
            if (picture == null) {
                return Maybe<Picture>.None;
            }
            return picture;
        }
    }
}
