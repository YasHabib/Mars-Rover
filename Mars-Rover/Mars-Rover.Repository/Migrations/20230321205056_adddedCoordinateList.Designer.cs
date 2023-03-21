﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Mars_Rover.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Mars_Rover.Repository.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20230321205056_adddedCoordinateList")]
    partial class adddedCoordinateList
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Mars_Rover.Models.Entities.RoverPosition", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("OutputResult")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("RoverId")
                        .HasColumnType("uuid");

                    b.Property<string>("UserInput")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<List<int>>("XYCoordinates")
                        .HasColumnType("integer[]");

                    b.HasKey("Id");

                    b.HasIndex("RoverId");

                    b.ToTable("RoverPositions");
                });

            modelBuilder.Entity("Mars_Rover.Models.Objects.Rover", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Rovers");
                });

            modelBuilder.Entity("Mars_Rover.Models.Entities.RoverPosition", b =>
                {
                    b.HasOne("Mars_Rover.Models.Objects.Rover", "Rover")
                        .WithMany("RoverPositions")
                        .HasForeignKey("RoverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rover");
                });

            modelBuilder.Entity("Mars_Rover.Models.Objects.Rover", b =>
                {
                    b.Navigation("RoverPositions");
                });
#pragma warning restore 612, 618
        }
    }
}
