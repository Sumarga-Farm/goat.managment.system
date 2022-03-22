namespace GoatFarm.Management.API.GoatManagement.Models.Commands
{
    public static class GenderExtensions
    {
        public static Domain.GoatManagement.Gender ToDomainType(this Gender gender) {
            if (gender == Gender.Male) {
                return Domain.GoatManagement.Gender.Male;
            }
            return Domain.GoatManagement.Gender.Female;
        }
    }
}
