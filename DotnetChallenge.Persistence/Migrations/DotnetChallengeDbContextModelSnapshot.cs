﻿// <auto-generated />
using System;
using DotnetChallenge.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DotnetChallenge.Persistence.Migrations
{
    [DbContext(typeof(DotnetChallengeDbContext))]
    partial class DotnetChallengeDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DotnetChallenge.Domain.Entities.Carrier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CarrierConfigurationId")
                        .HasColumnType("int");

                    b.Property<bool>("CarrierIsActive")
                        .HasColumnType("bit");

                    b.Property<string>("CarrierName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("CarrierPlusDesiCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Carriers");
                });

            modelBuilder.Entity("DotnetChallenge.Domain.Entities.CarrierConfiguration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("CarrierCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CarrierId")
                        .HasColumnType("int");

                    b.Property<int>("CarrierMaxDesi")
                        .HasColumnType("int");

                    b.Property<int>("CarrierMinDesi")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CarrierId");

                    b.ToTable("CarrierConfigurations");
                });

            modelBuilder.Entity("DotnetChallenge.Domain.Entities.CarrierReport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("CarrierCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CarrierId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CarrierReportDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("CarrierReports");
                });

            modelBuilder.Entity("DotnetChallenge.Domain.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CarrierId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("OrderCarrierCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderDesi")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarrierId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("DotnetChallenge.Domain.Entities.CarrierConfiguration", b =>
                {
                    b.HasOne("DotnetChallenge.Domain.Entities.Carrier", null)
                        .WithMany("CarrierConfigurations")
                        .HasForeignKey("CarrierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DotnetChallenge.Domain.Entities.Order", b =>
                {
                    b.HasOne("DotnetChallenge.Domain.Entities.Carrier", null)
                        .WithMany("Orders")
                        .HasForeignKey("CarrierId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("DotnetChallenge.Domain.Entities.Carrier", b =>
                {
                    b.Navigation("CarrierConfigurations");

                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
