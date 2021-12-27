﻿// <auto-generated />
using System;
using CleanArchitecture.Infrastucture.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CleanArchitecture.Infrastucture.Data.Migrations
{
    [DbContext(typeof(GetJobDbContext))]
    [Migration("20211227130346_Try")]
    partial class Try
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CleanArchitecture.DomainCore.Models.Classes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClassroomId")
                        .HasColumnType("int");

                    b.Property<string>("Period")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SubjectsId")
                        .HasColumnType("int");

                    b.Property<int?>("TeachersId")
                        .HasColumnType("int");

                    b.Property<int>("Time")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClassroomId");

                    b.HasIndex("SubjectsId");

                    b.HasIndex("TeachersId");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("CleanArchitecture.DomainCore.Models.Classroom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Classroom");
                });

            modelBuilder.Entity("CleanArchitecture.DomainCore.Models.StudentClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<int>("StudentsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("StudentsId");

                    b.ToTable("StudentClasses");
                });

            modelBuilder.Entity("CleanArchitecture.DomainCore.Models.Students", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Date_of_Birth")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name_of_Course")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number_of_Course")
                        .HasColumnType("int");

                    b.Property<string>("Student_Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("CleanArchitecture.DomainCore.Models.Subjects", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("CleanArchitecture.DomainCore.Models.Teachers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subjects_Taught")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Teacher_Image")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("CleanArchitecture.DomainCore.Models.Classes", b =>
                {
                    b.HasOne("CleanArchitecture.DomainCore.Models.Classroom", "Classroom")
                        .WithMany("Classes")
                        .HasForeignKey("ClassroomId");

                    b.HasOne("CleanArchitecture.DomainCore.Models.Subjects", "Subjects")
                        .WithMany("Classes")
                        .HasForeignKey("SubjectsId");

                    b.HasOne("CleanArchitecture.DomainCore.Models.Teachers", "Teachers")
                        .WithMany("Classes")
                        .HasForeignKey("TeachersId");

                    b.Navigation("Classroom");

                    b.Navigation("Subjects");

                    b.Navigation("Teachers");
                });

            modelBuilder.Entity("CleanArchitecture.DomainCore.Models.StudentClass", b =>
                {
                    b.HasOne("CleanArchitecture.DomainCore.Models.Classes", "Class")
                        .WithMany("StudentClasses")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CleanArchitecture.DomainCore.Models.Students", "Students")
                        .WithMany("StudentClasses")
                        .HasForeignKey("StudentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("CleanArchitecture.DomainCore.Models.Classes", b =>
                {
                    b.Navigation("StudentClasses");
                });

            modelBuilder.Entity("CleanArchitecture.DomainCore.Models.Classroom", b =>
                {
                    b.Navigation("Classes");
                });

            modelBuilder.Entity("CleanArchitecture.DomainCore.Models.Students", b =>
                {
                    b.Navigation("StudentClasses");
                });

            modelBuilder.Entity("CleanArchitecture.DomainCore.Models.Subjects", b =>
                {
                    b.Navigation("Classes");
                });

            modelBuilder.Entity("CleanArchitecture.DomainCore.Models.Teachers", b =>
                {
                    b.Navigation("Classes");
                });
#pragma warning restore 612, 618
        }
    }
}
