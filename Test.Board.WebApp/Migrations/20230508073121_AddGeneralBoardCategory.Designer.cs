﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Test.Board.WebApp.DataContext;

#nullable disable

namespace Test.Board.WebApp.Migrations
{
    [DbContext(typeof(BoardDbContext))]
    [Migration("20230508073121_AddGeneralBoardCategory")]
    partial class AddGeneralBoardCategory
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Test.Board.WebApp.Models.GeneralBoard", b =>
                {
                    b.Property<int>("Number")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Number"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contents")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Writer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Number");

                    b.ToTable("Boards");
                });

            modelBuilder.Entity("Test.Board.WebApp.Models.GeneralBoardCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("GeneralBoardCategory");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "유머"
                        },
                        new
                        {
                            Id = 2,
                            Name = "지식"
                        },
                        new
                        {
                            Id = 3,
                            Name = "기타"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
