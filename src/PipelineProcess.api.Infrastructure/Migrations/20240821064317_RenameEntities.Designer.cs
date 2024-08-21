﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PipelineProcess.api.Infrastructure.Data;

#nullable disable

namespace PipelineProcess.api.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240821064317_RenameEntities")]
    partial class RenameEntities
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PipelineProcess.api.Core.Aggregates.ProcessAggregate.Process", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(64)
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.ToTable("Process");
                });

            modelBuilder.Entity("PipelineProcess.api.Core.Aggregates.ProjectAggregate.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(64)
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("SchemaId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SchemaId");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("PipelineProcess.api.Core.Aggregates.SchemaAggregate.Schema", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(64)
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.ToTable("Schema");
                });

            modelBuilder.Entity("PipelineProcess.api.Core.SharedEntities.ProcessSheetEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AdminAcceptStatus")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid?>("TodoItemId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("TodoItemId");

                    b.ToTable("ProcessSheetEntity");
                });

            modelBuilder.Entity("PipelineProcess.api.Core.Aggregates.ProjectAggregate.Project", b =>
                {
                    b.HasOne("PipelineProcess.api.Core.Aggregates.SchemaAggregate.Schema", "Schema")
                        .WithMany("Projects")
                        .HasForeignKey("SchemaId");

                    b.Navigation("Schema");
                });

            modelBuilder.Entity("PipelineProcess.api.Core.SharedEntities.ProcessSheetEntity", b =>
                {
                    b.HasOne("PipelineProcess.api.Core.Aggregates.ProjectAggregate.Project", "Project")
                        .WithMany("ProjectProcesses")
                        .HasForeignKey("ProjectId");

                    b.HasOne("PipelineProcess.api.Core.Aggregates.ProcessAggregate.Process", "TodoItem")
                        .WithMany("ProcessSheets")
                        .HasForeignKey("TodoItemId");

                    b.Navigation("Project");

                    b.Navigation("TodoItem");
                });

            modelBuilder.Entity("PipelineProcess.api.Core.Aggregates.ProcessAggregate.Process", b =>
                {
                    b.Navigation("ProcessSheets");
                });

            modelBuilder.Entity("PipelineProcess.api.Core.Aggregates.ProjectAggregate.Project", b =>
                {
                    b.Navigation("ProjectProcesses");
                });

            modelBuilder.Entity("PipelineProcess.api.Core.Aggregates.SchemaAggregate.Schema", b =>
                {
                    b.Navigation("Projects");
                });
#pragma warning restore 612, 618
        }
    }
}
