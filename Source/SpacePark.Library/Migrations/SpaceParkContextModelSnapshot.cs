﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SpacePark.Library.Context;

namespace SpacePark.Library.Migrations
{
    [DbContext(typeof(SpaceParkContext))]
    partial class SpaceParkContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SpacePark.Library.Models.ParkingLot", b =>
                {
                    b.Property<int>("ParkingLotID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ParkingLotNO")
                        .HasColumnType("int");

                    b.Property<bool>("ParkingLotOccupied")
                        .HasColumnType("bit");

                    b.Property<int?>("SpacePortID")
                        .HasColumnType("int");

                    b.HasKey("ParkingLotID");

                    b.HasIndex("SpacePortID");

                    b.ToTable("ParkingLots");
                });

            modelBuilder.Entity("SpacePark.Library.Models.SpacePort", b =>
                {
                    b.Property<int>("SpacePortID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ParkingSpace")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("SpacePortID");

                    b.ToTable("SpacePorts");
                });

            modelBuilder.Entity("SpacePark.Library.Models.Visitor", b =>
                {
                    b.Property<int>("VisitorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("VisitorID");

                    b.ToTable("Visitors");
                });

            modelBuilder.Entity("SpacePark.Library.Models.VisitorParking", b =>
                {
                    b.Property<int>("VisitorParkingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ParkingLotID")
                        .HasColumnType("int");

                    b.Property<int>("ParkingNO")
                        .HasColumnType("int");

                    b.Property<int>("VisitorID")
                        .HasColumnType("int");

                    b.HasKey("VisitorParkingID");

                    b.HasIndex("ParkingLotID");

                    b.HasIndex("VisitorID");

                    b.ToTable("VisitorParking");
                });

            modelBuilder.Entity("SpacePark.Library.Models.ParkingLot", b =>
                {
                    b.HasOne("SpacePark.Library.Models.SpacePort", null)
                        .WithMany("ParkingLots")
                        .HasForeignKey("SpacePortID");
                });

            modelBuilder.Entity("SpacePark.Library.Models.VisitorParking", b =>
                {
                    b.HasOne("SpacePark.Library.Models.ParkingLot", "ParkingLot")
                        .WithMany("VisitorParking")
                        .HasForeignKey("ParkingLotID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SpacePark.Library.Models.Visitor", "Visitor")
                        .WithMany()
                        .HasForeignKey("VisitorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
