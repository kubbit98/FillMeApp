﻿// <auto-generated />
using FillMeApp.Server.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FillMeApp.Server.Migrations
{
    [DbContext(typeof(FillMeAppDbContext))]
    [Migration("20210604191013_FillMeAppFirstMigration")]
    partial class FillMeAppFirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.6");

            modelBuilder.Entity("FillMeApp.Shared.Models.Party", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(8)
                        .HasColumnType("varchar(8)");

                    b.Property<string>("Description")
                        .HasMaxLength(512)
                        .HasColumnType("varchar(512)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)");

                    b.HasKey("Id");

                    b.ToTable("Parties");

                    b.HasData(
                        new
                        {
                            Id = "party1",
                            Description = "Party for development",
                            Name = "Party number one"
                        },
                        new
                        {
                            Id = "party2",
                            Description = "Party for development",
                            Name = "Party number two"
                        });
                });

            modelBuilder.Entity("FillMeApp.Shared.Models.Survey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(512)
                        .HasColumnType("varchar(512)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)");

                    b.Property<string>("PartyId")
                        .HasColumnType("varchar(8)");

                    b.HasKey("Id");

                    b.HasIndex("PartyId");

                    b.ToTable("Surveys");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "For development",
                            Name = "First survey",
                            PartyId = "party1"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Second survey",
                            PartyId = "party1"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Third survey",
                            PartyId = "party2"
                        });
                });

            modelBuilder.Entity("FillMeApp.Shared.Models.User", b =>
                {
                    b.Property<string>("Login")
                        .HasMaxLength(8)
                        .HasColumnType("varchar(8)");

                    b.Property<string>("Nick")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("varchar(16)");

                    b.Property<string>("PartyId")
                        .HasColumnType("varchar(8)");

                    b.HasKey("Login");

                    b.HasIndex("PartyId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Login = "user1",
                            Nick = "Zuczek",
                            PartyId = "party1"
                        },
                        new
                        {
                            Login = "user2",
                            Nick = "Kornel",
                            PartyId = "party1"
                        },
                        new
                        {
                            Login = "user3",
                            Nick = "Szymek",
                            PartyId = "party2"
                        });
                });

            modelBuilder.Entity("FillMeApp.Shared.Models.Survey", b =>
                {
                    b.HasOne("FillMeApp.Shared.Models.Party", "Party")
                        .WithMany("Surveys")
                        .HasForeignKey("PartyId");

                    b.Navigation("Party");
                });

            modelBuilder.Entity("FillMeApp.Shared.Models.User", b =>
                {
                    b.HasOne("FillMeApp.Shared.Models.Party", "Party")
                        .WithMany("Users")
                        .HasForeignKey("PartyId");

                    b.Navigation("Party");
                });

            modelBuilder.Entity("FillMeApp.Shared.Models.Party", b =>
                {
                    b.Navigation("Surveys");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
