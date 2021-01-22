﻿// <auto-generated />
using System;
using Amin_Database_Project_AssetTracking_Solution;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Amin_Database_Project_AssetTracking_Solution.Migrations
{
    [DbContext(typeof(AssetContext))]
    partial class AssetContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Amin_Database_Project_AssetTracking_Solution.Asset", b =>
                {
                    b.Property<int>("AssetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Currency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ExchangeRate")
                        .HasColumnType("float");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("PurchasePrice")
                        .HasColumnType("float");

                    b.HasKey("AssetId");

                    b.ToTable("Asset");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Asset");
                });

            modelBuilder.Entity("Amin_Database_Project_AssetTracking_Solution.Office", b =>
                {
                    b.Property<int>("OfficeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AssetId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OfficeId");

                    b.HasIndex("AssetId")
                        .IsUnique();

                    b.ToTable("Office");
                });

            modelBuilder.Entity("Amin_Database_Project_AssetTracking_Solution.Computer", b =>
                {
                    b.HasBaseType("Amin_Database_Project_AssetTracking_Solution.Asset");

                    b.Property<int?>("AssetId1")
                        .HasColumnType("int");

                    b.Property<int>("ComputerId")
                        .HasColumnType("int");

                    b.HasIndex("AssetId1");

                    b.HasDiscriminator().HasValue("Computer");
                });

            modelBuilder.Entity("Amin_Database_Project_AssetTracking_Solution.Phone", b =>
                {
                    b.HasBaseType("Amin_Database_Project_AssetTracking_Solution.Asset");

                    b.Property<int?>("AssetId1")
                        .HasColumnType("int")
                        .HasColumnName("Phone_AssetId1");

                    b.Property<int>("PhoneId")
                        .HasColumnType("int");

                    b.HasIndex("AssetId1");

                    b.HasDiscriminator().HasValue("Phone");
                });

            modelBuilder.Entity("Amin_Database_Project_AssetTracking_Solution.Office", b =>
                {
                    b.HasOne("Amin_Database_Project_AssetTracking_Solution.Asset", "asset")
                        .WithOne("Office")
                        .HasForeignKey("Amin_Database_Project_AssetTracking_Solution.Office", "AssetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("asset");
                });

            modelBuilder.Entity("Amin_Database_Project_AssetTracking_Solution.Computer", b =>
                {
                    b.HasOne("Amin_Database_Project_AssetTracking_Solution.Asset", "asset")
                        .WithMany("computers")
                        .HasForeignKey("AssetId1");

                    b.Navigation("asset");
                });

            modelBuilder.Entity("Amin_Database_Project_AssetTracking_Solution.Phone", b =>
                {
                    b.HasOne("Amin_Database_Project_AssetTracking_Solution.Asset", "asset")
                        .WithMany("phones")
                        .HasForeignKey("AssetId1");

                    b.Navigation("asset");
                });

            modelBuilder.Entity("Amin_Database_Project_AssetTracking_Solution.Asset", b =>
                {
                    b.Navigation("computers");

                    b.Navigation("Office");

                    b.Navigation("phones");
                });
#pragma warning restore 612, 618
        }
    }
}
