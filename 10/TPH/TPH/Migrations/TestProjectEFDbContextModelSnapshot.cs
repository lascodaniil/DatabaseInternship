﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TPH;

namespace TPH.Migrations
{
    [DbContext(typeof(TestProjectEFDbContext))]
    partial class TestProjectEFDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Entities.BaseUniversity", b =>
                {
                    b.Property<int>("UniversityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("IsRowByte")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rector")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StudentsCapacity")
                        .HasColumnType("int");

                    b.HasKey("UniversityId");

                    b.ToTable("Universities");

                    b.HasDiscriminator<string>("Discriminator").HasValue("BaseUniversity");
                });

            modelBuilder.Entity("Domain.Entities.ArtUniversity", b =>
                {
                    b.HasBaseType("Domain.Entities.BaseUniversity");

                    b.Property<string>("PaintingRoom")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("ArtUniversity");
                });

            modelBuilder.Entity("Domain.Entities.MedicineUniversity", b =>
                {
                    b.HasBaseType("Domain.Entities.BaseUniversity");

                    b.Property<string>("AnatomyRoom")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("MedicineUniversity");
                });

            modelBuilder.Entity("Domain.Entities.TechUniversity", b =>
                {
                    b.HasBaseType("Domain.Entities.BaseUniversity");

                    b.Property<int>("Computers")
                        .HasColumnType("int");

                    b.Property<string>("TypeOfLaboratory")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("TechUniversity");
                });
#pragma warning restore 612, 618
        }
    }
}