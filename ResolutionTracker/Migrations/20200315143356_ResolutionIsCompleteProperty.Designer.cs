﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ResolutionTracker.Data;

namespace ResolutionTracker.Migrations
{
    [DbContext(typeof(ResolutionTrackerContext))]
    [Migration("20200315143356_ResolutionIsCompleteProperty")]
    partial class ResolutionIsCompleteProperty
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("ResolutionTracker.Data.Models.Common.Resolution", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DateCompleted")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("Deadline")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsComplete")
                        .HasColumnType("boolean");

                    b.Property<int>("PercentageCompleted")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Resolutions");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Resolution");
                });

            modelBuilder.Entity("ResolutionTracker.Data.Models.CodingResolution", b =>
                {
                    b.HasBaseType("ResolutionTracker.Data.Models.Common.Resolution");

                    b.Property<string>("Technology")
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue("CodingResolution");
                });

            modelBuilder.Entity("ResolutionTracker.Data.Models.HealthResolution", b =>
                {
                    b.HasBaseType("ResolutionTracker.Data.Models.Common.Resolution");

                    b.Property<string>("HealthArea")
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue("HealthResolution");
                });

            modelBuilder.Entity("ResolutionTracker.Data.Models.LanguageResolution", b =>
                {
                    b.HasBaseType("ResolutionTracker.Data.Models.Common.Resolution");

                    b.Property<string>("Language")
                        .HasColumnType("text");

                    b.Property<string>("Skill")
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue("LanguageResolution");
                });

            modelBuilder.Entity("ResolutionTracker.Data.Models.MusicResolution", b =>
                {
                    b.HasBaseType("ResolutionTracker.Data.Models.Common.Resolution");

                    b.Property<string>("Instrument")
                        .HasColumnType("text");

                    b.Property<string>("MusicGenre")
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue("MusicResolution");
                });
#pragma warning restore 612, 618
        }
    }
}
