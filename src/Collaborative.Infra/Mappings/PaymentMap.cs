using Collaborative.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Collaborative.Infra.Mappings
{
    public class PaymentMap : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder
                .ToTable("Payment");

            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Paid)
                .HasColumnType("DATETIME2")
                .HasDefaultValue(null);

            builder
                .Property(x => x.Total)
                .HasColumnType("DOUBLE")
                .IsRequired();

            builder
                .Property(x => x.Details)
                .HasColumnType("VARCHAR(200)")
                .HasMaxLength(200)
                .IsRequired();

            builder
                .HasOne(x => x.FinancialAccount)
                .WithMany(x => x.Payments)
                .HasForeignKey(x => x.FinancialAccountId);

            builder
                .HasOne(x => x.Order)
                .WithMany(x => x.Payments)
                .HasForeignKey(x => x.OrderId);
        }
    }
}
