using Domain.BuyerAggregate;
using Domain.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(x => x.Id);
            builder.Ignore(x => x.Events);

            builder.OwnsOne(o => o.DeliveryAddress, a =>
             {
                 a.Property<int>("OrderId").UseHiLo("orderseq");
                 a.WithOwner();
             });
            builder.OwnsOne(o => o.CardInformation, a =>
            {
                a.Property<int>("OrderId").UseHiLo("orderseq");
                a.WithOwner();
            });

            builder.HasOne<Buyer>()
            .WithMany()
            .IsRequired()
            .HasForeignKey(x => x.BuyerId);

            builder.HasOne<OrderStatus>().WithMany()
            .IsRequired()
            .HasForeignKey(x => x.StatusId);

            builder.HasMany<OrderItem>(x => x.OrderItems)
            .WithOne()
            .IsRequired()
            .HasForeignKey("OrderId");

            builder.Metadata.FindNavigation(nameof(Order.OrderItems)).SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}