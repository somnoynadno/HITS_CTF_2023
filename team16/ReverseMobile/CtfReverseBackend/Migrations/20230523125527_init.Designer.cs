﻿// <auto-generated />
using System;
using CtfReverseBackend.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CtfReverseBackend.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20230523125527_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CtfReverseBackend.DAL.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("boolean");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Login")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("08eecf32-b20f-491f-8e6c-0ffd25bd6e3f"),
                            IsAdmin = true,
                            Login = "administrator",
                            Password = "obamahamburgersussyballs"
                        },
                        new
                        {
                            Id = new Guid("fbeb7912-12ec-4756-ba29-33ab83e81918"),
                            IsAdmin = false,
                            Login = "user",
                            Password = "password"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
