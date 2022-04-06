﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
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
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("api.Models.Database.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

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

            modelBuilder.Entity("api.Models.Database.ClassSpell", b =>
                {
                    b.Property<int>("ClassId")
                        .HasColumnType("integer");

                    b.Property<int>("SpellId")
                        .HasColumnType("integer");

                    b.Property<int>("Level")
                        .HasColumnType("integer");

                    b.HasKey("ClassId", "SpellId");

                    b.HasIndex("SpellId");

                    b.ToTable("ClassSpell");
                });

            modelBuilder.Entity("api.Models.Database.Descriptor", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Id")
                        .HasColumnType("integer");

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
                            Name = "Figment",
                            Id = 57
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
                            Name = "Language-Dependent",
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
                            Name = "Mind-Affecting",
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

            modelBuilder.Entity("api.Models.Database.SourceMaterial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("SourceMaterial");
                });

            modelBuilder.Entity("api.Models.Database.Spell", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Area")
                        .HasColumnType("text");

                    b.Property<string>("Bloodline")
                        .HasColumnType("text");

                    b.Property<string>("CastingTime")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ComponentDetails")
                        .HasColumnType("text");

                    b.Property<string>("Deity")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Domain")
                        .HasColumnType("text");

                    b.Property<string>("Duration")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Effect")
                        .HasColumnType("text");

                    b.Property<bool>("HasCostlyComponents")
                        .HasColumnType("boolean");

                    b.Property<bool>("HasDivineFocusComponent")
                        .HasColumnType("boolean");

                    b.Property<bool>("HasFocusComponent")
                        .HasColumnType("boolean");

                    b.Property<bool>("HasMaterialComponent")
                        .HasColumnType("boolean");

                    b.Property<bool>("HasSomaticComponent")
                        .HasColumnType("boolean");

                    b.Property<bool>("HasVerbalComponent")
                        .HasColumnType("boolean");

                    b.Property<string>("HauntStatistics")
                        .HasColumnType("text");

                    b.Property<bool>("IsDismissable")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsMythic")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsShapeable")
                        .HasColumnType("boolean");

                    b.Property<int?>("MaterialCosts")
                        .HasColumnType("integer");

                    b.Property<string>("MythicAugmented")
                        .HasColumnType("text");

                    b.Property<string>("MythicText")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Patron")
                        .HasColumnType("text");

                    b.Property<string>("Range")
                        .HasColumnType("text");

                    b.Property<string>("SavingThrow")
                        .HasColumnType("text");

                    b.Property<string>("School")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("SourceId")
                        .HasColumnType("integer");

                    b.Property<string>("SpellResistance")
                        .HasColumnType("text");

                    b.Property<string>("Subschool")
                        .HasColumnType("text");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Targets")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("SourceId");

                    b.ToTable("Spell");
                });

            modelBuilder.Entity("DescriptorSpell", b =>
                {
                    b.Property<string>("DescriptorsName")
                        .HasColumnType("text");

                    b.Property<int>("SpellsId")
                        .HasColumnType("integer");

                    b.HasKey("DescriptorsName", "SpellsId");

                    b.HasIndex("SpellsId");

                    b.ToTable("DescriptorSpell");
                });

            modelBuilder.Entity("api.Models.Database.ClassSpell", b =>
                {
                    b.HasOne("api.Models.Database.Class", "Class")
                        .WithMany("ClassSpells")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.Database.Spell", "Spell")
                        .WithMany("ClassSpells")
                        .HasForeignKey("SpellId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("Spell");
                });

            modelBuilder.Entity("api.Models.Database.Spell", b =>
                {
                    b.HasOne("api.Models.Database.SourceMaterial", "Source")
                        .WithMany()
                        .HasForeignKey("SourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Source");
                });

            modelBuilder.Entity("DescriptorSpell", b =>
                {
                    b.HasOne("api.Models.Database.Descriptor", null)
                        .WithMany()
                        .HasForeignKey("DescriptorsName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.Database.Spell", null)
                        .WithMany()
                        .HasForeignKey("SpellsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("api.Models.Database.Class", b =>
                {
                    b.Navigation("ClassSpells");
                });

            modelBuilder.Entity("api.Models.Database.Spell", b =>
                {
                    b.Navigation("ClassSpells");
                });
#pragma warning restore 612, 618
        }
    }
}
