using Collaborative.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Collaborative.Infra.Mappings
{
    public class FinancialAccountMap : IEntityTypeConfiguration<FinancialAccount>
    {
        public void Configure(EntityTypeBuilder<FinancialAccount> builder)
        {
            builder
                .ToTable("FinancialAccount");

            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Open)
                .HasColumnType("DATETIME2")
                .HasDefaultValue(DateTime.Now)
                .IsRequired();

            builder
                .Property(x => x.Close)
                .HasColumnType("DATETIME2")
                .HasDefaultValue(null);

            builder
                .HasOne(x => x.Collaborative)
                .WithMany(x => x.FinancialAccounts)
                .HasForeignKey(x => x.CollaborativeId);
        }
    }
}
