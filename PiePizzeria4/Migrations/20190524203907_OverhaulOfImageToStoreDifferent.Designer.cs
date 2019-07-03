﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PiePizzeria.Data;

namespace PiePizzeria.Migrations
{
    [DbContext(typeof(PizzaContext))]
    [Migration("20190524203907_OverhaulOfImageToStoreDifferent")]
    partial class OverhaulOfImageToStoreDifferent
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PiePizzeria.Models.Pie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("Image");

                    b.Property<string>("ImageContentType");

                    b.Property<bool>("IsPieOfTheWeek");

                    b.Property<string>("LongDescription")
                        .IsRequired()
                        .HasMaxLength(1000);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<decimal>("Price");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Pie");
                });
#pragma warning restore 612, 618
        }
    }
}
