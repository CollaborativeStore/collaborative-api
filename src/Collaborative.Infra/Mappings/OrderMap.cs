using Collaborative.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Collaborative.Infra.Mappings
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                .ToTable("Order");

            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Ordered)
                .HasColumnType("DATETIME2")
                .HasDefaultValue(DateTime.Now)
                .IsRequired();

            builder
                .Property(x => x.Status)
                .IsRequired();

            builder
                .Property(x => x.Total)
                .HasColumnType("DECIMAL(5,2)")
                .HasDefaultValue(0);

            builder
                .HasOne(x => x.Collaborative)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.CollaborativeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(x => x.Products)
                .WithOne(x => x.Order)
                .HasForeignKey(x => x.OrderId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
