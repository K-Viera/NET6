﻿// <auto-generated />
using System;
using ConsoleAppEFCodeFirst.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ConsoleAppEFCodeFirst.Migrations
{
    [DbContext(typeof(SchoolContext))]
    [Migration("20220712200148_RelationCourseAndStudent")]
    partial class RelationCourseAndStudent
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ConsoleAppEFCodeFirst.Models.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseId"), 1L, 1);

                    b.Property<string>("CourseName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("CourseId");

                    b.HasIndex("StudentId");

                    b.ToTable("courses");
                });

            modelBuilder.Entity("ConsoleAppEFCodeFirst.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentId"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StudentId1")
                        .HasColumnType("int");

                    b.HasKey("StudentId");

                    b.HasIndex("StudentId1");

                    b.ToTable("students");
                });

            modelBuilder.Entity("ConsoleAppEFCodeFirst.Models.Course", b =>
                {
                    b.HasOne("ConsoleAppEFCodeFirst.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("ConsoleAppEFCodeFirst.Models.Student", b =>
                {
                    b.HasOne("ConsoleAppEFCodeFirst.Models.Student", null)
                        .WithMany("Students")
                        .HasForeignKey("StudentId1");
                });

            modelBuilder.Entity("ConsoleAppEFCodeFirst.Models.Student", b =>
                {
                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
