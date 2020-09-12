using Collaborative.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Collaborative.Infra.Mappings
{
    public class OrderProductMap : IEntityTypeConfiguration<OrderProduct>
    {
        public void Configure(EntityTypeBuilder<OrderProduct> builder)
        {
            builder
                .ToTable("OrderProduct");

            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Quantity)
                .IsRequired()
                .HasDefaultValue(1);

            builder
                .Property(x => x.Value)
                .HasColumnType("DECIMAL(5,2)")
                .IsRequired();

            builder
                .HasOne(x => x.Product)
                .WithOne(x => x.OrderProduct)
                .HasForeignKey<OrderProduct>(x => x.ProductId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
                
        }
    }
}
