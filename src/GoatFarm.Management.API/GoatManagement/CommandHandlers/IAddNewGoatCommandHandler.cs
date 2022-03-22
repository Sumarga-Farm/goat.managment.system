using GoatFarm.Management.API.GoatManagement.Models.Commands;

namespace GoatFarm.Management.API.GoatManagement.CommandHandlers
{
    public interface IAddNewGoatCommandHandler
    {
        Task<AddNewGoatResponse> HandleAsync(AddNewGoatCommand command);
    }
}