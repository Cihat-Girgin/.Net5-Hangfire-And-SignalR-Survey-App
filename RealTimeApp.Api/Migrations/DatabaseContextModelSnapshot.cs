﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RealTimeApp.Api.Models;

namespace RealTimeApp.Api.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RealTimeApp.Api.Models.BackendFramework", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BackendFrameworks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = ".Net Core"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Spring Boot"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Ruby"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Laravel"
                        },
                        new
                        {
                            Id = 5,
                            Name = "ExpressJs"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Django"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Koa"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Flask"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Symfony"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Phoenix"
                        });
                });

            modelBuilder.Entity("RealTimeApp.Api.Models.SurveyItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BackendFrameworkId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("SurveyItems");
                });
#pragma warning restore 612, 618
        }
    }
}
