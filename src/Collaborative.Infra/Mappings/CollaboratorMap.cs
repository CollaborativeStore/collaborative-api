using Collaborative.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Collaborative.Infra.Mappings
{
    public class CollaboratorMap : IEntityTypeConfiguration<Collaborator>
    {
        public void Configure(EntityTypeBuilder<Collaborator> builder)
        {
            builder.ToTable("Collaborator");

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
                .Property(x => x.Mail)
                .HasColumnType("VARCHAR(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(x => x.CreationDate)
                .HasColumnType("DATETIME2")
                .HasDefaultValue(DateTime.Now)
                .IsRequired();

            builder
                .Property(x => x.ClosingDate)
                .HasDefaultValue(null);

            builder
                .HasOne(x => x.Collaborative)
                .WithMany(x => x.Collaborators)
                .HasForeignKey(x => x.CollaborativeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
