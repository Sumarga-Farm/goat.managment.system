

using GoatFarm.Management.API.GoatManagement.Models.Commands;
using GoatFarm.Management.API.MediaManagement.Controllers;
using Microsoft.AspNetCore.Mvc;
using Humanizer;
namespace GoatFarm.Management.API.GoatManagement
{
    public class GoatDetailResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string IdentityDescription { get; set; }
        public Gender Gender { get; set; }
        public double DateOfBirthInUnixTimeMilliseconds { get; set; }
        public string Age { get; set; }
        public string? GoatPictureUrl { get; set; }
        internal static GoatDetailResponse From(Domain.GoatManagement.Goat goat, IUrlHelper urlHelper)
        {
            return new GoatDetailResponse
            {
                Id = goat.Id,
                Name = goat.Name,
                IdentityDescription = goat.IdentityDescription,
                Gender = ToResponse(goat.Gender),
                DateOfBirthInUnixTimeMilliseconds = goat.DateOfBirth.ToUnixTimeMilliseconds(),
                Age = (DateTimeOffset.UtcNow - goat.DateOfBirth).Humanize(precision: 2, 
                                                                            minUnit: Humanizer.Localisation.TimeUnit.Day, 
                                                                            maxUnit: Humanizer.Localisation.TimeUnit.Year),
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