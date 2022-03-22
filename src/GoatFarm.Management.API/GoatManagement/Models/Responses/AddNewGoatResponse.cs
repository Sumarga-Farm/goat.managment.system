using GoatFarm.Management.Domain.GoatManagement;

namespace GoatFarm.Management.API.GoatManagement.CommandHandlers
{
    public class AddNewGoatResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        internal static AddNewGoatResponse From(Goat goat)
        {
            return new AddNewGoatResponse { Id = goat.Id, Name = goat.Name };
        }
    }
}