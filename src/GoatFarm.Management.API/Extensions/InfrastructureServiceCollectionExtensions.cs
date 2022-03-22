using GoatFarm.Management.Domain.GoatManagement;
using GoatFarm.Management.Domain.IdentityManagement;
using GoatFarm.Management.Domain.MediaManagement;
using GoatFarm.Management.Infrastructure;
using GoatFarm.Management.Infrastructure.GoatManagement.Repositories;
using GoatFarm.Management.Infrastructure.IdentityManagement;
using GoatFarm.Management.Infrastructure.IdentityManagement.Repositories;
using GoatFarm.Management.Infrastructure.MediaManagement.Repositories;
using Microsoft.EntityFrameworkCore;
namespace Microsoft.Extensions.DependencyInjection
{
    public static class InfrastructureServiceCollectionExtensions
    {
        public static IServiceCollection AddGoatFarmManagementInfrastructureServices(
               this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<GoatFarmManagementDbContext>(option =>
            {
                option
                .UseNpgsql("name=ConnectionStrings:GoatFarmManagement", sqlServerOptions =>
                {
                    sqlServerOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorCodesToAdd: null);
                });
            }, contextLifetime: ServiceLifetime.Scoped);

            services.AddScoped<IPictureRepository, PictureRepository>();
            services.AddScoped<IGoatRepository, GoatRepository>();
            services.AddScoped<ITagRepository, TagRepository>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.Configure<IdentityOptions>(configuration.GetSection(nameof(IdentityOptions)));
            return services;
        }
    }
}
