﻿// <auto-generated />
using System;
using Collaborative.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Collaborative.Infra.Migrations
{
    [DbContext(typeof(EntityContext))]
    [Migration("20200912130058_RefatoringStockClass")]
    partial class RefatoringStockClass
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Collaborative.Domain.Models.Collaborative", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CNPJ")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("VARCHAR(14)")
                        .HasMaxLength(14)
                        .HasDefaultValue(null);

                    b.Property<string>("CPF")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("VARCHAR(11)")
                        .HasMaxLength(11)
                        .HasDefaultValue(null);

                    b.Property<DateTime?>("ClosingDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(null);

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME2")
                        .HasDefaultValue(new DateTime(2020, 9, 12, 10, 0, 58, 169, DateTimeKind.Local).AddTicks(7486));

                    b.Property<string>("Mail")
                        .HasColumnType("VARCHAR(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("VARCHAR(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Phone2")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("VARCHAR(10)")
                        .HasMaxLength(10)
                        .HasDefaultValue(null);

                    b.Property<int>("StockId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StockId")
                        .IsUnique();

                    b.ToTable("Collaborative");
                });

            modelBuilder.Entity("Collaborative.Domain.Models.Collaborator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CNPJ")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("VARCHAR(14)")
                        .HasMaxLength(14)
                        .HasDefaultValue(null);

                    b.Property<string>("CPF")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("VARCHAR(11)")
                        .HasMaxLength(11)
                        .HasDefaultValue(null);

                    b.Property<DateTime?>("ClosingDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(null);

                    b.Property<int>("CollaborativeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME2")
                        .HasDefaultValue(new DateTime(2020, 9, 12, 10, 0, 58, 169, DateTimeKind.Local).AddTicks(8760));

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("VARCHAR(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Phone2")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("VARCHAR(10)")
                        .HasMaxLength(10)
                        .HasDefaultValue(null);

                    b.HasKey("Id");

                    b.HasIndex("CollaborativeId");

                    b.ToTable("Collaborator");
                });

            modelBuilder.Entity("Collaborative.Domain.Models.FinancialAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Close")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME2")
                        .HasDefaultValue(null);

                    b.Property<int>("CollaborativeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("Open")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME2")
                        .HasDefaultValue(new DateTime(2020, 9, 12, 10, 0, 58, 169, DateTimeKind.Local).AddTicks(9787));

                    b.HasKey("Id");

                    b.HasIndex("CollaborativeId");

                    b.ToTable("FinancialAccount");
                });

            modelBuilder.Entity("Collaborative.Domain.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CollaborativeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Ordered")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME2")
                        .HasDefaultValue(new DateTime(2020, 9, 12, 10, 0, 58, 170, DateTimeKind.Local).AddTicks(657));

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<decimal>("Total")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DECIMAL(5,2)")
                        .HasDefaultValue(0m);

                    b.HasKey("Id");

                    b.HasIndex("CollaborativeId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("Collaborative.Domain.Models.OrderProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<decimal>("Value")
                        .HasColumnType("DECIMAL(5,2)");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("OrderProduct");
                });

            modelBuilder.Entity("Collaborative.Domain.Models.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("VARCHAR(200)")
                        .HasMaxLength(200);

                    b.Property<int>("FinancialAccountId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Paid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME2")
                        .HasDefaultValue(null);

                    b.Property<decimal>("Total")
                        .HasColumnType("DECIMAL(6,2)");

                    b.HasKey("Id");

                    b.HasIndex("FinancialAccountId");

                    b.HasIndex("OrderId");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("Collaborative.Domain.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CollaboratorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME2")
                        .HasDefaultValue(new DateTime(2020, 9, 12, 10, 0, 58, 170, DateTimeKind.Local).AddTicks(6798));

                    b.Property<DateTime?>("DeletionDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME2")
                        .HasDefaultValue(null);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)")
                        .HasMaxLength(50);

                    b.Property<int>("Quantity")
                        .HasColumnType("INT");

                    b.Property<int>("StockId")
                        .HasColumnType("int");

                    b.Property<decimal>("UnityPrice")
                        .HasColumnType("DECIMAL(5,2)");

                    b.HasKey("Id");

                    b.HasIndex("CollaboratorId");

                    b.HasIndex("StockId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Collaborative.Domain.Models.Stock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Stock");
                });

            modelBuilder.Entity("Collaborative.Domain.Models.Collaborative", b =>
                {
                    b.HasOne("Collaborative.Domain.Models.Stock", "Stock")
                        .WithOne("Collaborative")
                        .HasForeignKey("Collaborative.Domain.Models.Collaborative", "StockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Collaborative.Domain.Models.Collaborator", b =>
                {
                    b.HasOne("Collaborative.Domain.Models.Collaborative", "Collaborative")
                        .WithMany("Collaborators")
                        .HasForeignKey("CollaborativeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Collaborative.Domain.Models.FinancialAccount", b =>
                {
                    b.HasOne("Collaborative.Domain.Models.Collaborative", "Collaborative")
                        .WithMany("FinancialAccounts")
                        .HasForeignKey("CollaborativeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Collaborative.Domain.Models.Order", b =>
                {
                    b.HasOne("Collaborative.Domain.Models.Collaborative", "Collaborative")
                        .WithMany("Orders")
                        .HasForeignKey("CollaborativeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Collaborative.Domain.Models.OrderProduct", b =>
                {
                    b.HasOne("Collaborative.Domain.Models.Order", "Order")
                        .WithMany("Products")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Collaborative.Domain.Models.Product", "Product")
                        .WithOne("OrderProduct")
                        .HasForeignKey("Collaborative.Domain.Models.OrderProduct", "ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Collaborative.Domain.Models.Payment", b =>
                {
                    b.HasOne("Collaborative.Domain.Models.FinancialAccount", "FinancialAccount")
                        .WithMany("Payments")
                        .HasForeignKey("FinancialAccountId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Collaborative.Domain.Models.Order", "Order")
                        .WithMany("Payments")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Collaborative.Domain.Models.Product", b =>
                {
                    b.HasOne("Collaborative.Domain.Models.Collaborator", "Collaborator")
                        .WithMany("Products")
                        .HasForeignKey("CollaboratorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Collaborative.Domain.Models.Stock", "Stock")
                        .WithMany("Products")
                        .HasForeignKey("StockId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
