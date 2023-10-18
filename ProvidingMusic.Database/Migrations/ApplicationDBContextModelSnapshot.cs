﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ProvidingMusic.Database.Context;

#nullable disable

namespace ProvidingMusic.DataBase.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ProvidingMusic.Domain.Models.Album", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("BandId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("YearOfRelease")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BandId");

                    b.ToTable("Albums");
                });

            modelBuilder.Entity("ProvidingMusic.Domain.Models.Band", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Bands");
                });

            modelBuilder.Entity("ProvidingMusic.Domain.Models.GroupMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("BandId")
                        .HasColumnType("integer");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BandId");

                    b.ToTable("GroupMembers");
                });

            modelBuilder.Entity("ProvidingMusic.Domain.Models.Song", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("AlbumId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("SequenceNumber")
                        .HasColumnType("integer");

                    b.Property<int>("SongDuration")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.ToTable("Songs");
                });

            modelBuilder.Entity("ProvidingMusic.Domain.Models.Album", b =>
                {
                    b.HasOne("ProvidingMusic.Domain.Models.Band", null)
                        .WithMany("Albums")
                        .HasForeignKey("BandId");
                });

            modelBuilder.Entity("ProvidingMusic.Domain.Models.GroupMember", b =>
                {
                    b.HasOne("ProvidingMusic.Domain.Models.Band", null)
                        .WithMany("GroupMembers")
                        .HasForeignKey("BandId");
                });

            modelBuilder.Entity("ProvidingMusic.Domain.Models.Song", b =>
                {
                    b.HasOne("ProvidingMusic.Domain.Models.Album", null)
                        .WithMany("ListSongs")
                        .HasForeignKey("AlbumId");
                });

            modelBuilder.Entity("ProvidingMusic.Domain.Models.Album", b =>
                {
                    b.Navigation("ListSongs");
                });

            modelBuilder.Entity("ProvidingMusic.Domain.Models.Band", b =>
                {
                    b.Navigation("Albums");

                    b.Navigation("GroupMembers");
                });
#pragma warning restore 612, 618
        }
    }
}
