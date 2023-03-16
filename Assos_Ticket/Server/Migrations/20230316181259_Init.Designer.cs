﻿// <auto-generated />
using System;
using Assos_Ticket.Server.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Assos_Ticket.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230316181259_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Assos_Ticket.Shared.BusExpedition", b =>
                {
                    b.Property<int>("BusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BusId"), 1L, 1);

                    b.Property<string>("Begining")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BeginingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("BusName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Capacitiy")
                        .HasColumnType("int");

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ExpeditionId")
                        .HasColumnType("int");

                    b.Property<string>("Finish")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FinisingDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Price")
                        .HasColumnType("Decimal(18,2)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("BusId");

                    b.HasIndex("ExpeditionId");

                    b.ToTable("Busses");
                });

            modelBuilder.Entity("Assos_Ticket.Shared.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Assos_Ticket.Shared.Expedition", b =>
                {
                    b.Property<int>("ExpeditionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExpeditionId"), 1L, 1);

                    b.HasKey("ExpeditionId");

                    b.ToTable("Expeditions");
                });

            modelBuilder.Entity("Assos_Ticket.Shared.PlaneExpedition", b =>
                {
                    b.Property<int>("PlaneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlaneId"), 1L, 1);

                    b.Property<string>("Begining")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BeginingDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ExpeditionId")
                        .HasColumnType("int");

                    b.Property<string>("Finish")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FinisingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PlaneName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("Decimal(18,2)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("PlaneId");

                    b.HasIndex("ExpeditionId");

                    b.ToTable("Planes");
                });

            modelBuilder.Entity("Assos_Ticket.Shared.Ticket", b =>
                {
                    b.Property<int>("TicketID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TicketID"), 1L, 1);

                    b.Property<DateTime>("BoughtDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("ExpeditionId")
                        .HasColumnType("int");

                    b.Property<int>("SeatNo")
                        .HasColumnType("int");

                    b.HasKey("TicketID");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ExpeditionId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("Assos_Ticket.Shared.BusExpedition", b =>
                {
                    b.HasOne("Assos_Ticket.Shared.Expedition", null)
                        .WithMany("BusExpeditions")
                        .HasForeignKey("ExpeditionId");
                });

            modelBuilder.Entity("Assos_Ticket.Shared.PlaneExpedition", b =>
                {
                    b.HasOne("Assos_Ticket.Shared.Expedition", null)
                        .WithMany("PlaneExpeditions")
                        .HasForeignKey("ExpeditionId");
                });

            modelBuilder.Entity("Assos_Ticket.Shared.Ticket", b =>
                {
                    b.HasOne("Assos_Ticket.Shared.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Assos_Ticket.Shared.Expedition", "Expedition")
                        .WithMany()
                        .HasForeignKey("ExpeditionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Expedition");
                });

            modelBuilder.Entity("Assos_Ticket.Shared.Expedition", b =>
                {
                    b.Navigation("BusExpeditions");

                    b.Navigation("PlaneExpeditions");
                });
#pragma warning restore 612, 618
        }
    }
}