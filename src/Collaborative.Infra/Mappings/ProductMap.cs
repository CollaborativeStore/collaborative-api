using Collaborative.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Collaborative.Infra.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .ToTable("Product");

            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Name)
                .HasColumnType("VARCHAR(50)")
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(x => x.CreationDate)
                .HasColumnType("DATETIME2")
                .HasDefaultValue(DateTime.Now)
                .IsRequired();

            builder
                .Property(x => x.DeletionDate)
                .HasColumnType("DATETIME2")
                .HasDefaultValue(null);

            builder
                .Property(x => x.UnityPrice)
                .HasColumnType("DECIMAL(5,2)")
                .IsRequired();

            builder
                .HasOne(x => x.Collaborator)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CollaboratorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Stock)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.StockId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Order)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.OrderId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
