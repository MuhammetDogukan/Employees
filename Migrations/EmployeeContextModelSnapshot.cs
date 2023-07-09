﻿// <auto-generated />
using Empoyees.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Empoyees.Migrations
{
    [DbContext(typeof(EmployeeContext))]
    partial class EmployeeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Empoyee.Model.Employee", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)")
                        .HasDefaultValueSql("dbo.GenerateRandomId(11)");

                    b.Property<string>("EmployeeId")
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Manager")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Empoyee.Model.Employee", b =>
                {
                    b.HasOne("Empoyee.Model.Employee", null)
                        .WithMany("Subordinate")
                        .HasForeignKey("EmployeeId");
                });

            modelBuilder.Entity("Empoyee.Model.Employee", b =>
                {
                    b.Navigation("Subordinate");
                });
#pragma warning restore 612, 618
        }
    }
}
