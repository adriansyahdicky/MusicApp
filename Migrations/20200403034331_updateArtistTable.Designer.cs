﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MusicRoom.Data;

namespace MusicRoom.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200403034331_updateArtistTable")]
    partial class updateArtistTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MusicRoom.Domain.Artists", b =>
                {
                    b.Property<long>("ArtistID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AlbumName")
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ArtistName")
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ImageURL")
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SampleURL")
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("ArtistID");

                    b.ToTable("Artists");
                });
#pragma warning restore 612, 618
        }
    }
}