﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api.Data;

#nullable disable

namespace api.Migrations
{
    [DbContext(typeof(ApiContext))]
    partial class ApiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("api.Models.Descriptor", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.HasKey("Name");

                    b.ToTable("Descriptor");

                    b.HasData(
                        new
                        {
                            Name = "Acid",
                            Id = 29
                        },
                        new
                        {
                            Name = "Air",
                            Id = 30
                        },
                        new
                        {
                            Name = "Chaotic",
                            Id = 31
                        },
                        new
                        {
                            Name = "Cold",
                            Id = 32
                        },
                        new
                        {
                            Name = "Curse",
                            Id = 33
                        },
                        new
                        {
                            Name = "Darkness",
                            Id = 34
                        },
                        new
                        {
                            Name = "Death",
                            Id = 35
                        },
                        new
                        {
                            Name = "Disease",
                            Id = 36
                        },
                        new
                        {
                            Name = "Draconic",
                            Id = 37
                        },
                        new
                        {
                            Name = "Earth",
                            Id = 38
                        },
                        new
                        {
                            Name = "Electricity",
                            Id = 39
                        },
                        new
                        {
                            Name = "Emotion",
                            Id = 40
                        },
                        new
                        {
                            Name = "Evil",
                            Id = 41
                        },
                        new
                        {
                            Name = "Fear",
                            Id = 42
                        },
                        new
                        {
                            Name = "Fire",
                            Id = 43
                        },
                        new
                        {
                            Name = "Force",
                            Id = 44
                        },
                        new
                        {
                            Name = "Good",
                            Id = 45
                        },
                        new
                        {
                            Name = "LanguageDependent",
                            Id = 46
                        },
                        new
                        {
                            Name = "Lawful",
                            Id = 47
                        },
                        new
                        {
                            Name = "Light",
                            Id = 48
                        },
                        new
                        {
                            Name = "Meditative",
                            Id = 49
                        },
                        new
                        {
                            Name = "MindAffecting",
                            Id = 50
                        },
                        new
                        {
                            Name = "Pain",
                            Id = 51
                        },
                        new
                        {
                            Name = "Poison",
                            Id = 52
                        },
                        new
                        {
                            Name = "Ruse",
                            Id = 53
                        },
                        new
                        {
                            Name = "Shadow",
                            Id = 54
                        },
                        new
                        {
                            Name = "Sonic",
                            Id = 55
                        },
                        new
                        {
                            Name = "Water",
                            Id = 56
                        });
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

                    b.Property<string>("Deity")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Domain")
                        .HasColumnType("TEXT");

                    b.Property<string>("Duration")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Effect")
                        .HasColumnType("TEXT");

                    b.Property<bool>("HasCostlyComponents")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("HasDivineFocusComponent")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("HasFocusComponent")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("HasMaterialComponent")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("HasSomaticComponent")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("HasVerbalComponent")
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

            modelBuilder.Entity("api.Models.SpellDescriptor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DescriptorName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("SpellId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("DescriptorName");

                    b.HasIndex("SpellId");

                    b.ToTable("SpellDescriptor");
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

            modelBuilder.Entity("api.Models.SpellDescriptor", b =>
                {
                    b.HasOne("api.Models.Descriptor", "Descriptor")
                        .WithMany()
                        .HasForeignKey("DescriptorName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.Spell", "Spell")
                        .WithMany("Descriptors")
                        .HasForeignKey("SpellId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Descriptor");

                    b.Navigation("Spell");
                });

            modelBuilder.Entity("api.Models.Spell", b =>
                {
                    b.Navigation("ClassLevels");

                    b.Navigation("Descriptors");
                });
#pragma warning restore 612, 618
        }
    }
}
