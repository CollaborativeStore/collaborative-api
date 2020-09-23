using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Collab = Collaborative.Domain.Models.Collaborative;

namespace Collaborative.Infra.Mappings
{
    public class CollaborativeMap : IEntityTypeConfiguration<Collab>
    {
        public void Configure(EntityTypeBuilder<Collab> builder)
        {
            builder.ToTable("Collaborative");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasColumnType("VARCHAR(50)")
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(x => x.Phone)
                .HasColumnType("VARCHAR(10)")
                .HasMaxLength(10)
                .IsRequired();

            builder
                .Property(x => x.Phone2)
                .HasColumnType("VARCHAR(10)")
                .HasMaxLength(10)
                .HasDefaultValue(null);

            builder
                .Property(x => x.CPF)
                .HasDefaultValue(null)
                .HasColumnType("VARCHAR(11)")
                .HasMaxLength(11);


            builder
                .Property(x => x.CNPJ)
                .HasDefaultValue(null)
                .HasColumnType("VARCHAR(14)")
                .HasMaxLength(14);

            builder
                .Property(x => x.Email)
                .HasColumnType("VARCHAR(100)")
                .HasMaxLength(100);

            builder
                .Property(x => x.CreationDate)
                .HasColumnType("DATETIME2")
                .HasDefaultValue(DateTime.Now)
                .IsRequired();

            builder
                .Property(x => x.ClosingDate)
                .HasDefaultValue(null);
        }
    }
}
