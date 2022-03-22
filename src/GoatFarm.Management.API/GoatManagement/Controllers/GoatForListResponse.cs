using GoatFarm.Management.API.GoatManagement.Models.Commands;
using GoatFarm.Management.API.MediaManagement.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace GoatFarm.Management.API.GoatManagement
{
    public class GoatForListResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public string? GoatPictureUrl { get; set; }
        internal static GoatForListResponse From(Domain.GoatManagement.Goat goat, IUrlHelper urlHelper)
        {
            return new GoatForListResponse
            {
                Id = goat.Id,
                Name = goat.Name,
                Gender = ToResponse(goat.Gender),
                GoatPictureUrl = urlHelper.GetGoatPictureUrl(goat.PictureId)
            };
        }

        private static Gender ToResponse(Domain.GoatManagement.Gender gender)
        {
            if (gender == Domain.GoatManagement.Gender.Male)
            {
                return Gender.Male;
            }
            return Gender.Female;
        }
    }
}