using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Backend.Web.Database.Implementation;

namespace Web.Migrations
{
    [DbContext(typeof(PostgresDbContext))]
    [Migration("20161122174952_Second")]
    partial class Second
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

            modelBuilder.Entity("Domain.Model.Database.Achievement", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitude");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Achievements");
                });

            modelBuilder.Entity("Domain.Model.Database.Building", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Buildings");
                });

            modelBuilder.Entity("Domain.Model.Database.Faculty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("BuildingId");

                    b.Property<long>("LogoId");

                    b.Property<string>("Name");

                    b.Property<string>("ShortName");

                    b.HasKey("Id");

                    b.HasIndex("BuildingId");

                    b.HasIndex("LogoId")
                        .IsUnique();

                    b.ToTable("Faculties");
                });

            modelBuilder.Entity("Domain.Model.Database.Logo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("Content");

                    b.Property<string>("ContentType");

                    b.Property<long>("FacultyId");

                    b.Property<string>("FileName");

                    b.HasKey("Id");

                    b.ToTable("Logos");
                });

            modelBuilder.Entity("Domain.Model.Database.Place", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("BuildingId");

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitude");

                    b.HasKey("Id");

                    b.HasIndex("BuildingId");

                    b.ToTable("Places");
                });

            modelBuilder.Entity("Domain.Model.Database.Faculty", b =>
                {
                    b.HasOne("Domain.Model.Database.Building")
                        .WithMany("Faculties")
                        .HasForeignKey("BuildingId");

                    b.HasOne("Domain.Model.Database.Logo", "Logo")
                        .WithOne("Faculty")
                        .HasForeignKey("Domain.Model.Database.Faculty", "LogoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Model.Database.Place", b =>
                {
                    b.HasOne("Domain.Model.Database.Building", "Building")
                        .WithMany("Places")
                        .HasForeignKey("BuildingId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
