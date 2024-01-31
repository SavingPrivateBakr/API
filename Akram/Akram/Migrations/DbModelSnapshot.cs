﻿// <auto-generated />
using System;
using Akram.Models.DBc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Akram.Migrations
{
    [DbContext(typeof(Dbase))]
    partial class DbModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Akram.Models.Account", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("CanEdit")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Akram.Models.Journal", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EntryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SourceID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Journals");
                });

            modelBuilder.Entity("Akram.Models.JournalDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AccountID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Credit")
                        .HasColumnType("float");

                    b.Property<double>("Debit")
                        .HasColumnType("float");

                    b.Property<Guid>("JournalID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AccountID");

                    b.HasIndex("JournalID");

                    b.ToTable("JournalDetails");
                });

            modelBuilder.Entity("Akram.Models.JournalDetail", b =>
                {
                    b.HasOne("Akram.Models.Account", "Account")
                        .WithMany("JournalDetails")
                        .HasForeignKey("AccountID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Akram.Models.Journal", "Journal")
                        .WithMany("JournalDetails")
                        .HasForeignKey("JournalID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Journal");
                });

            modelBuilder.Entity("Akram.Models.Account", b =>
                {
                    b.Navigation("JournalDetails");
                });

            modelBuilder.Entity("Akram.Models.Journal", b =>
                {
                    b.Navigation("JournalDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
