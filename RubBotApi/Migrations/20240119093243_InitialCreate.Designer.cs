﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RubBotApi.Data;

#nullable disable

namespace RubBotApi.Migrations
{
    [DbContext(typeof(RubBotContext))]
    [Migration("20240119093243_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AreaProject", b =>
                {
                    b.Property<string>("AreasId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProjectsId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("AreasId", "ProjectsId");

                    b.HasIndex("ProjectsId");

                    b.ToTable("AreaProject");
                });

            modelBuilder.Entity("AreaResource", b =>
                {
                    b.Property<string>("AreasId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ResourcesId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("AreasId", "ResourcesId");

                    b.HasIndex("ResourcesId");

                    b.ToTable("AreaResource");
                });

            modelBuilder.Entity("ProjectResource", b =>
                {
                    b.Property<string>("ProjectsId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ResourcesId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ProjectsId", "ResourcesId");

                    b.HasIndex("ResourcesId");

                    b.ToTable("ProjectResource");
                });

            modelBuilder.Entity("RubBotApi.Models.Area", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AreaCover")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAchieved")
                        .HasColumnType("bit");

                    b.Property<string>("LabelId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LabelsId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LabelId");

                    b.HasIndex("LabelsId");

                    b.ToTable("Areas");

                    b.HasData(
                        new
                        {
                            Id = "e163ea7c7e495a08",
                            AreaCover = "user",
                            IsAchieved = false,
                            LabelId = "1f81a686-1531-11e8-16e5-f0d5bf731f61",
                            Name = "Personal"
                        },
                        new
                        {
                            Id = "691460af7e50befd",
                            AreaCover = "dumbbell",
                            IsAchieved = false,
                            LabelId = "6f81a112-6678-11e8-66e5-f0d534f731f66",
                            Name = "Health & Fitness"
                        },
                        new
                        {
                            Id = "6e3ab353ba1f109a",
                            AreaCover = "briefcase",
                            IsAchieved = false,
                            LabelId = "2f99a636-2111-11e8-26e5-f0d534f731f62",
                            Name = "Work"
                        },
                        new
                        {
                            Id = "dce86ddd2b57d888",
                            AreaCover = "money-bill-trend-up",
                            IsAchieved = false,
                            LabelId = "3f81a686-3531-11e8-36e5-f0d534f731f63",
                            Name = "Side Hustle"
                        },
                        new
                        {
                            Id = "31483485000784f6",
                            AreaCover = "route",
                            IsAchieved = false,
                            LabelId = "1f81a686-1531-11e8-16e5-f0d5bf731f61",
                            Name = "Travel"
                        },
                        new
                        {
                            Id = "8850a149a403ea70",
                            AreaCover = "leanpub",
                            IsAchieved = false,
                            LabelId = "4f81a612-4531-11e8-46e5-f0d534f731f64",
                            Name = "Learning"
                        });
                });

            modelBuilder.Entity("RubBotApi.Models.Labels", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Labels");

                    b.HasData(
                        new
                        {
                            Id = "1f81a686-1531-11e8-16e5-f0d5bf731f61",
                            Name = "Personal"
                        },
                        new
                        {
                            Id = "2f99a636-2111-11e8-26e5-f0d534f731f62",
                            Name = "Work"
                        },
                        new
                        {
                            Id = "3f81a686-3531-11e8-36e5-f0d534f731f63",
                            Name = "Business"
                        },
                        new
                        {
                            Id = "4f81a612-4531-11e8-46e5-f0d534f731f64",
                            Name = "School"
                        },
                        new
                        {
                            Id = "5f81a789-5234-11e8-56e5-f0d534f731f65",
                            Name = "Productivity"
                        },
                        new
                        {
                            Id = "6f81a112-6678-11e8-66e5-f0d534f731f66",
                            Name = "Fitness"
                        },
                        new
                        {
                            Id = "7f81a632-7012-11e8-76e5-f0d534f731f67",
                            Name = "Investment"
                        });
                });

            modelBuilder.Entity("RubBotApi.Models.Project", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsAchieved")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("StatusId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            Id = "0d0b5c4d6ab2f474",
                            EndDate = new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsAchieved = false,
                            Name = "Sample Project",
                            StartDate = new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StatusId = "2f81a686-7531-11e8-86e5-f0d5bf731f68"
                        });
                });

            modelBuilder.Entity("RubBotApi.Models.Resource", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Favorite")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAchieved")
                        .HasColumnType("bit");

                    b.Property<string>("LabelId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StatusId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LabelId");

                    b.HasIndex("StatusId");

                    b.ToTable("Resources");
                });

            modelBuilder.Entity("RubBotApi.Models.Status", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Status");

                    b.HasData(
                        new
                        {
                            Id = "2f81a686-7531-11e8-86e5-f0d5bf731f68",
                            Name = "Inbox"
                        },
                        new
                        {
                            Id = "2f81a123-1234-11e8-86e5-f0d5bf731f68",
                            Name = "Planned"
                        },
                        new
                        {
                            Id = "2f81a456-5678-11e8-86e5-f0d5bf731f68",
                            Name = "In Progress"
                        },
                        new
                        {
                            Id = "2f81a789-9012-11e8-86e5-f0d5bf731f68",
                            Name = "Done"
                        });
                });

            modelBuilder.Entity("RubBotApi.Models.Tasks", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Done")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAchieved")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectsId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ResourcesId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ProjectsId");

                    b.HasIndex("ResourcesId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("AreaProject", b =>
                {
                    b.HasOne("RubBotApi.Models.Area", null)
                        .WithMany()
                        .HasForeignKey("AreasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RubBotApi.Models.Project", null)
                        .WithMany()
                        .HasForeignKey("ProjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AreaResource", b =>
                {
                    b.HasOne("RubBotApi.Models.Area", null)
                        .WithMany()
                        .HasForeignKey("AreasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RubBotApi.Models.Resource", null)
                        .WithMany()
                        .HasForeignKey("ResourcesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjectResource", b =>
                {
                    b.HasOne("RubBotApi.Models.Project", null)
                        .WithMany()
                        .HasForeignKey("ProjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RubBotApi.Models.Resource", null)
                        .WithMany()
                        .HasForeignKey("ResourcesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RubBotApi.Models.Area", b =>
                {
                    b.HasOne("RubBotApi.Models.Labels", "Labels")
                        .WithMany()
                        .HasForeignKey("LabelId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RubBotApi.Models.Labels", null)
                        .WithMany("Areas")
                        .HasForeignKey("LabelsId");

                    b.Navigation("Labels");
                });

            modelBuilder.Entity("RubBotApi.Models.Project", b =>
                {
                    b.HasOne("RubBotApi.Models.Status", "Status")
                        .WithMany("Projects")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Status");
                });

            modelBuilder.Entity("RubBotApi.Models.Resource", b =>
                {
                    b.HasOne("RubBotApi.Models.Labels", "Labels")
                        .WithMany("Resources")
                        .HasForeignKey("LabelId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RubBotApi.Models.Status", "Status")
                        .WithMany("Resources")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Labels");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("RubBotApi.Models.Tasks", b =>
                {
                    b.HasOne("RubBotApi.Models.Project", "Projects")
                        .WithMany("Tasks")
                        .HasForeignKey("ProjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RubBotApi.Models.Resource", "Resources")
                        .WithMany("Tasks")
                        .HasForeignKey("ResourcesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Projects");

                    b.Navigation("Resources");
                });

            modelBuilder.Entity("RubBotApi.Models.Labels", b =>
                {
                    b.Navigation("Areas");

                    b.Navigation("Resources");
                });

            modelBuilder.Entity("RubBotApi.Models.Project", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("RubBotApi.Models.Resource", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("RubBotApi.Models.Status", b =>
                {
                    b.Navigation("Projects");

                    b.Navigation("Resources");
                });
#pragma warning restore 612, 618
        }
    }
}