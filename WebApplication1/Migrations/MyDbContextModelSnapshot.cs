﻿// <auto-generated />
using System;
using DoranOfficeBackend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DoranOfficeBackend.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DoranOfficeBackend.Entities.KeylessCount", b =>
                {
                    b.Property<int>("RowCount")
                        .HasColumnType("int");

                    b.ToView("View_Count");
                });

            modelBuilder.Entity("DoranOfficeBackend.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("active")
                        .HasDefaultValueSql("'1'");

                    b.Property<DateTime?>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("'NULL'");

                    b.Property<DateTime?>("DeletedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasColumnName("deleted_at")
                        .HasDefaultValueSql("'NULL'");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("name");

                    b.Property<DateTime?>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasColumnName("updated_at")
                        .HasDefaultValueSql("'NULL'");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "Name" }, "roles_name_unique")
                        .IsUnique();

                    b.ToTable("roles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("60e5c903-93ab-4142-a202-73873dfc71b9"),
                            Active = false,
                            Name = "superadmin"
                        });
                });

            modelBuilder.Entity("DoranOfficeBackend.Entities.Sales", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("active");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp")
                        .HasColumnName("deleted_at");

                    b.Property<bool>("GetOmzetEmail")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("get_omzet_email");

                    b.Property<bool>("IsManager")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_manager");

                    b.Property<Guid?>("ManagerId")
                        .HasColumnType("char(36)")
                        .HasColumnName("manager_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("name");

                    b.Property<Guid>("SalesTeamlId")
                        .HasColumnType("char(36)")
                        .HasColumnName("sales_team_id");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("ManagerId");

                    b.HasIndex("SalesTeamlId");

                    b.ToTable("sales");
                });

            modelBuilder.Entity("DoranOfficeBackend.Entities.SalesChannel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id");

                    b.Property<bool?>("Active")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("active");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp")
                        .HasColumnName("deleted_at");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("name");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.ToTable("saleschannels");
                });

            modelBuilder.Entity("DoranOfficeBackend.Entities.SalesTeam", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("active");

                    b.Property<bool>("CommissionTerms")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("commission_terms");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp")
                        .HasColumnName("deleted_at");

                    b.Property<ulong>("JeteTarget")
                        .HasColumnType("bigint unsigned")
                        .HasColumnName("jete_target");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("name");

                    b.Property<ulong>("OmzetTarget")
                        .HasColumnType("bigint unsigned")
                        .HasColumnName("omzet_target");

                    b.Property<Guid>("SalesChannelId")
                        .HasColumnType("char(36)")
                        .HasColumnName("sales_channel_id");

                    b.Property<bool>("ShowLastYear")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("show_last_year");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("SalesChannelId");

                    b.ToTable("salesteams");
                });

            modelBuilder.Entity("DoranOfficeBackend.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("active")
                        .HasDefaultValueSql("'1'");

                    b.Property<string>("ApiToken")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("api_token")
                        .HasDefaultValueSql("'NULL'");

                    b.Property<DateTime?>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("'NULL'");

                    b.Property<DateTime?>("DeletedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasColumnName("deleted_at")
                        .HasDefaultValueSql("'NULL'");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("password");

                    b.Property<string>("PasswordText")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("passwordText");

                    b.Property<string>("RememberToken")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("remember_token")
                        .HasDefaultValueSql("'NULL'");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("char(36)")
                        .HasColumnName("role_id");

                    b.Property<Guid?>("SalesId")
                        .HasColumnType("char(36)")
                        .HasColumnName("sales_id");

                    b.Property<DateTime?>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasColumnName("updated_at")
                        .HasDefaultValueSql("'NULL'");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("username");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex("SalesId")
                        .IsUnique();

                    b.HasIndex(new[] { "ApiToken" }, "users_api_token_unique")
                        .IsUnique();

                    b.HasIndex(new[] { "RoleId" }, "users_role_id_foreign");

                    b.HasIndex(new[] { "Username" }, "users_username_unique")
                        .IsUnique();

                    b.ToTable("users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("dd271bd1-e883-4d96-a82c-c11d6fbc9862"),
                            Active = false,
                            Password = "$2a$11$.aWnw4S5hS8YElM0ZSE1r.QxsLfeekSHLYspJWr9sGqRH0Paeseui",
                            PasswordText = "superadmin",
                            RoleId = new Guid("60e5c903-93ab-4142-a202-73873dfc71b9"),
                            Username = "superadmin"
                        });
                });

            modelBuilder.Entity("DoranOfficeBackend.Entities.Sales", b =>
                {
                    b.HasOne("DoranOfficeBackend.Entities.Sales", "Manager")
                        .WithMany()
                        .HasForeignKey("ManagerId");

                    b.HasOne("DoranOfficeBackend.Entities.SalesTeam", "SalesTeam")
                        .WithMany("Sales")
                        .HasForeignKey("SalesTeamlId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("sales_sales_team_id_foreign");

                    b.Navigation("Manager");

                    b.Navigation("SalesTeam");
                });

            modelBuilder.Entity("DoranOfficeBackend.Entities.SalesTeam", b =>
                {
                    b.HasOne("DoranOfficeBackend.Entities.SalesChannel", "SalesChannel")
                        .WithMany("SalesTeams")
                        .HasForeignKey("SalesChannelId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("sales_sales_channel_id_foreign");

                    b.Navigation("SalesChannel");
                });

            modelBuilder.Entity("DoranOfficeBackend.Entities.User", b =>
                {
                    b.HasOne("DoranOfficeBackend.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("users_role_id_foreign");

                    b.HasOne("DoranOfficeBackend.Entities.Sales", "Sales")
                        .WithOne("User")
                        .HasForeignKey("DoranOfficeBackend.Entities.User", "SalesId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("users_sales_id_foreign");

                    b.Navigation("Role");

                    b.Navigation("Sales");
                });

            modelBuilder.Entity("DoranOfficeBackend.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("DoranOfficeBackend.Entities.Sales", b =>
                {
                    b.Navigation("User");
                });

            modelBuilder.Entity("DoranOfficeBackend.Entities.SalesChannel", b =>
                {
                    b.Navigation("SalesTeams");
                });

            modelBuilder.Entity("DoranOfficeBackend.Entities.SalesTeam", b =>
                {
                    b.Navigation("Sales");
                });
#pragma warning restore 612, 618
        }
    }
}