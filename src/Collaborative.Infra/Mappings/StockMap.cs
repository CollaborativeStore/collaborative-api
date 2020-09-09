using Collaborative.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Collab = Collaborative.Domain.Models.Collaborative;

namespace Collaborative.Infra.Mappings
{
    public class StockMap : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder
                .ToTable("Stock");

            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Quantity)
                .HasColumnType("INT")
                .IsRequired();

            builder
                .HasOne(x => x.Collaborative)
                .WithOne(x => x.Stock)
                .HasForeignKey<Collab>(x => x.StockId);
        }
    }
}
