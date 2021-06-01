using Domain.BuyerAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class BuyerConfiguration : IEntityTypeConfiguration<Buyer>
    {
        public void Configure(EntityTypeBuilder<Buyer> builder)
        {
            builder.ToTable("Buyers");
            builder.HasKey(x => x.Id);
            builder.Ignore(x => x.Events);
            builder.Property(x => x.Name).HasMaxLength(300).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(150).IsRequired();
        }
    }
}