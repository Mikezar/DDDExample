using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using Domain.Abstract;
using System.Linq;
using Infrastructure.Configuration;
using Domain.BuyerAggregate;
using Domain.ProductAggregate;
using Domain.OrderAggregate;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Db
{
    public class DDDContext : DbContext
    {
        private readonly IMediator _mediator;

        public DbSet<Buyer> Buyers {get; set;}
        public DbSet<Product> Products {get; set;}
        public DbSet<Order> Orders {get; set;}
        public DbSet<OrderItem> OrderItems {get; set;}
        public DbSet<OrderStatus> OrderStates {get; set;}

        public DDDContext(DbContextOptions<DDDContext> contextOptions, IMediator mediator) : base(contextOptions)
        {
            _mediator = mediator;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BuyerConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderItemConfiguration());
            modelBuilder.ApplyConfiguration(new OrderStatusConfiguration());
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entities = this.ChangeTracker.Entries<Entity>().Where(x => x.Entity.Events?.Any() == true);
            var events = entities.SelectMany(x => x.Entity.Events).ToList();

            entities.ToList().ForEach(e => e.Entity.ClearEvents());

            foreach (var @event in events)
            {
                await _mediator.Publish(@event);
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

        public class DDDContextDesignFactory : IDesignTimeDbContextFactory<DDDContext>
        {
            public DDDContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<DDDContext>()
                .UseNpgsql("User ID=postgres;Password=116833;Host=localhost;Port=5432;Database=DDDExample;Pooling=true;");

                return new DDDContext(optionsBuilder.Options, null);
            }
        }
    }
}