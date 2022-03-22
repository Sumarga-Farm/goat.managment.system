using GoatFarm.Management.API.GoatManagement.CommandHandlers;
using GoatFarm.Management.API.IdentityManagement;
using GoatFarm.Management.API.MediaManagement.CommandHandlers;
using GoatFarm.Management.API.MediaManagement.Controllers;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ApiServiceCollectionExtensions
    {
        public static IServiceCollection AddGoatFarmManagementApiServices(
                  this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAddNewGoatCommandHandler, AddNewGoatCommandHandler>();
            services.AddScoped<IPictureUploadCommandHandler, PictureUploadCommandHandler>();
            services.Configure<PictureUploadOptions>(configuration.GetSection(nameof(PictureUploadOptions)));
            services.AddScoped<IAccessTokenService, AccessTokenService>();
            services.Configure<AccessTokenOptions>(configuration.GetSection(nameof(AccessTokenOptions)));
            return services;
        }
    }
}
