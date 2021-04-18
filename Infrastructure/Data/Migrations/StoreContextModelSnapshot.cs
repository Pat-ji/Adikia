﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Data.Migrations
{
    [DbContext(typeof(StoreContext))]
    partial class StoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1");

            modelBuilder.Entity("Core.Entities.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("GameId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT")
                        .HasMaxLength(64);

                    b.Property<string>("ResourceUrl")
                        .HasColumnType("TEXT")
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("Core.Entities.CharacterDialogue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CharacterId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CharacterStage")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DialogueId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.HasIndex("DialogueId");

                    b.ToTable("CharacterDialogues");
                });

            modelBuilder.Entity("Core.Entities.CharacterDialogueAction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CharacterDialogueId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("NextCharacterStage")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("NextGameStage")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TriggerWord")
                        .HasColumnType("TEXT")
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.HasIndex("CharacterDialogueId");

                    b.ToTable("CharacterDialogueActions");
                });

            modelBuilder.Entity("Core.Entities.Dialogue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Messages")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Dialogues");
                });

            modelBuilder.Entity("Core.Entities.Evidence", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT")
                        .HasMaxLength(64);

                    b.Property<string>("ResourceUrl")
                        .HasColumnType("TEXT")
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.ToTable("Evidence");
                });

            modelBuilder.Entity("Core.Entities.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CompletedGameStage")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT")
                        .HasMaxLength(64);

                    b.Property<string>("ResourceUrl")
                        .HasColumnType("TEXT")
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("Core.Entities.GameDialogue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DialogueId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GameId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GameStage")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("GameDialogues");
                });

            modelBuilder.Entity("Core.Entities.GameDialogueAction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Action")
                        .HasColumnType("TEXT")
                        .HasMaxLength(128);

                    b.Property<int>("GameDialogueId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NextGameStage")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("GameDialogueId");

                    b.ToTable("GameDialogueActions");
                });

            modelBuilder.Entity("Core.Entities.Hint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("GameId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GameStage")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Information")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("Hints");
                });

            modelBuilder.Entity("Core.Entities.Identity.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AppUserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("State")
                        .HasColumnType("TEXT");

                    b.Property<string>("Street")
                        .HasColumnType("TEXT");

                    b.Property<string>("ZipCode")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId")
                        .IsUnique();

                    b.ToTable("Address");
                });

            modelBuilder.Entity("Core.Entities.Identity.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("DisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("AppUser");
                });

            modelBuilder.Entity("Core.Entities.Session", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AppUserId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("FinishDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("GameId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GameStage")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("GameId");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("Core.Entities.SessionCharacter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CharacterId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CharacterStage")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SessionId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("SessionId");

                    b.ToTable("SessionCharacters");
                });

            modelBuilder.Entity("Core.Entities.SessionEvidence", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("EvidenceId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SessionId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("SessionId");

                    b.ToTable("SessionEvidence");
                });

            modelBuilder.Entity("Core.Entities.UnlockableEvidence", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("EvidenceId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GameId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GameStage")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("EvidenceId");

                    b.HasIndex("GameId");

                    b.ToTable("UnlockableEvidences");
                });

            modelBuilder.Entity("Core.Entities.UserGame", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AppUserId")
                        .HasColumnType("TEXT");

                    b.Property<int>("GameId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("GameId1")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("GameId");

                    b.HasIndex("GameId1");

                    b.ToTable("UserGames");
                });

            modelBuilder.Entity("Core.Entities.Character", b =>
                {
                    b.HasOne("Core.Entities.Game", "Game")
                        .WithMany("Characters")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Entities.CharacterDialogue", b =>
                {
                    b.HasOne("Core.Entities.Character", "Character")
                        .WithMany("CharacterDialogues")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Dialogue", "Dialogue")
                        .WithMany("CharacterDialogues")
                        .HasForeignKey("DialogueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Entities.CharacterDialogueAction", b =>
                {
                    b.HasOne("Core.Entities.CharacterDialogue", "CharacterDialogue")
                        .WithMany("CharacterDialogueActions")
                        .HasForeignKey("CharacterDialogueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Entities.GameDialogue", b =>
                {
                    b.HasOne("Core.Entities.Dialogue", "Dialogue")
                        .WithMany("GameDialogues")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Game", "Game")
                        .WithMany("GameDialogues")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Entities.GameDialogueAction", b =>
                {
                    b.HasOne("Core.Entities.GameDialogue", "GameDialogue")
                        .WithMany("GameDialogueActions")
                        .HasForeignKey("GameDialogueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Entities.Hint", b =>
                {
                    b.HasOne("Core.Entities.Game", "Game")
                        .WithMany("Hints")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Entities.Identity.Address", b =>
                {
                    b.HasOne("Core.Entities.Identity.AppUser", "AppUser")
                        .WithOne("Address")
                        .HasForeignKey("Core.Entities.Identity.Address", "AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Entities.Session", b =>
                {
                    b.HasOne("Core.Entities.Identity.AppUser", "AppUser")
                        .WithMany("Sessions")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Core.Entities.Game", "Game")
                        .WithMany("Sessions")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Entities.SessionCharacter", b =>
                {
                    b.HasOne("Core.Entities.Character", "Character")
                        .WithMany("SessionCharacters")
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Session", "Session")
                        .WithMany("SessionCharacters")
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Entities.SessionEvidence", b =>
                {
                    b.HasOne("Core.Entities.Evidence", "Evidence")
                        .WithMany("SessionEvidence")
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Session", "Session")
                        .WithMany("SessionEvidence")
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Entities.UnlockableEvidence", b =>
                {
                    b.HasOne("Core.Entities.Evidence", "Evidence")
                        .WithMany("UnlockableEvidence")
                        .HasForeignKey("EvidenceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Game", "Game")
                        .WithMany("UnlockableEvidence")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Entities.UserGame", b =>
                {
                    b.HasOne("Core.Entities.Identity.AppUser", "User")
                        .WithMany()
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Core.Entities.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Game", null)
                        .WithMany("UserGames")
                        .HasForeignKey("GameId1");
                });
#pragma warning restore 612, 618
        }
    }
}
