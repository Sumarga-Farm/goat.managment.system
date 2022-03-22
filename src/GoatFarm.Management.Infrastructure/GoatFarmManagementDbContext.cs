using GoatFarm.Management.Domain.GoatManagement;
using GoatFarm.Management.Domain.MediaManagement;
using GoatFarm.Management.Domain.SharedKernel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GoatFarm.Management.Infrastructure
{
    public class GoatFarmManagementDbContext : DbContext, IUnitOfWork
    {
        private readonly IMediator _mediator;

        public DbSet<Goat> Goats { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public GoatFarmManagementDbContext(DbContextOptions<GoatFarmManagementDbContext> options)
        : base(options)
        {
        }
        public GoatFarmManagementDbContext(
            DbContextOptions<GoatFarmManagementDbContext> options,
            IMediator mediator)
           : base(options)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            // Dispatch Domain Events collection. 
            // Choices:
            // A) Right BEFORE committing data (EF SaveChanges) into the DB will make a single transaction including  
            // side effects from the domain event handlers which are using the same DbContext with "InstancePerLifetimeScope" or "scoped" lifetime
            // B) Right AFTER committing data (EF SaveChanges) into the DB will make multiple transactions. 
            // You will need to handle eventual consistency and compensatory actions in case of failures in any of the Handlers. 

            //Choosing option A for now for simplicity
            await DispatchDomainEvents();

            // After executing this line all the changes (from the Command Handler and Domain Event Handlers) 
            // performed through the DbContext will be committed
            var result = await base.SaveChangesAsync(cancellationToken);
            return result;
        }

        private async Task DispatchDomainEvents()
        {
            if (_mediator is not null)
            {
                await _mediator.DispatchDomainEventsAsync(this);
            }
        }
    }
}
