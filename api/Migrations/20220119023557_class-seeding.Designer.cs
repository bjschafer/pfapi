﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api.Data;

#nullable disable

namespace api.Migrations
{
    [DbContext(typeof(ApiContext))]
    [Migration("20220119023557_class-seeding")]
    partial class classseeding
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.1");

            modelBuilder.Entity("api.Models.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Class");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Adept"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Alchemist"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Antipaladin"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Bard"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Bloodrager"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Cleric"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Druid"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Hunter"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Inquisitor"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Investigator"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Magus"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Medium"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Mesmerist"
                        },
                        new
                        {
                            Id = 14,
                            Name = "Occultist"
                        },
                        new
                        {
                            Id = 15,
                            Name = "Oracle"
                        },
                        new
                        {
                            Id = 16,
                            Name = "Paladin"
                        },
                        new
                        {
                            Id = 17,
                            Name = "Psychic"
                        },
                        new
                        {
                            Id = 18,
                            Name = "Ranger"
                        },
                        new
                        {
                            Id = 19,
                            Name = "Shaman"
                        },
                        new
                        {
                            Id = 20,
                            Name = "Scald"
                        },
                        new
                        {
                            Id = 21,
                            Name = "SpellLikeAbility"
                        },
                        new
                        {
                            Id = 22,
                            Name = "Sorcerer"
                        },
                        new
                        {
                            Id = 23,
                            Name = "Spiritualist"
                        },
                        new
                        {
                            Id = 24,
                            Name = "Summoner"
                        },
                        new
                        {
                            Id = 25,
                            Name = "SummonerUnchained"
                        },
                        new
                        {
                            Id = 26,
                            Name = "Witch"
                        },
                        new
                        {
                            Id = 27,
                            Name = "Wizard"
                        });
                });

            modelBuilder.Entity("api.Models.ClassLevel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClassId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Level")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("SpellId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("SpellId");

                    b.ToTable("ClassLevel");
                });

            modelBuilder.Entity("api.Models.SourceMaterial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("SourceMaterial");
                });

            modelBuilder.Entity("api.Models.Spell", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Area")
                        .HasColumnType("TEXT");

                    b.Property<string>("Bloodline")
                        .HasColumnType("TEXT");

                    b.Property<string>("CastingTime")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Components")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Deity")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("Descriptors")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Domain")
                        .HasColumnType("TEXT");

                    b.Property<string>("Duration")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Effect")
                        .HasColumnType("TEXT");

                    b.Property<bool>("HasCostlyComponents")
                        .HasColumnType("INTEGER");

                    b.Property<string>("HauntStatistics")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDismissable")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsMythic")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsShapeable")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("MaterialCosts")
                        .HasColumnType("INTEGER");

                    b.Property<string>("MythicAugmented")
                        .HasColumnType("TEXT");

                    b.Property<string>("MythicText")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Patron")
                        .HasColumnType("TEXT");

                    b.Property<string>("Range")
                        .HasColumnType("TEXT");

                    b.Property<string>("SavingThrow")
                        .HasColumnType("TEXT");

                    b.Property<string>("School")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("SourceId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SpellResistance")
                        .HasColumnType("TEXT");

                    b.Property<string>("Subschool")
                        .HasColumnType("TEXT");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Targets")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("SourceId");

                    b.ToTable("Spell");
                });

            modelBuilder.Entity("api.Models.ClassLevel", b =>
                {
                    b.HasOne("api.Models.Class", "Class")
                        .WithMany()
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.Spell", null)
                        .WithMany("ClassLevels")
                        .HasForeignKey("SpellId");

                    b.Navigation("Class");
                });

            modelBuilder.Entity("api.Models.Spell", b =>
                {
                    b.HasOne("api.Models.SourceMaterial", "Source")
                        .WithMany()
                        .HasForeignKey("SourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Source");
                });

            modelBuilder.Entity("api.Models.Spell", b =>
                {
                    b.Navigation("ClassLevels");
                });
#pragma warning restore 612, 618
        }
    }
}
