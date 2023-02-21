﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SmsSender.Models;

namespace SmsSender.Migrations
{
    [DbContext(typeof(SendDBContext))]
    partial class SendDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("SmsSender.Models.Response", b =>
                {
                    b.Property<int>("IdR")
                        .HasColumnType("integer")
                        .HasColumnName("idR");

                    b.Property<string>("Result")
                        .HasColumnType("character varying");

                    b.HasKey("IdR")
                        .HasName("Response_pkey");

                    b.ToTable("Response", "SendDB");
                });

            modelBuilder.Entity("SmsSender.Models.Sender", b =>
                {
                    b.Property<int>("IdS")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("idS")
                        .UseIdentityAlwaysColumn();

                    b.Property<string>("Login")
                        .HasColumnType("character varying")
                        .HasColumnName("login");

                    b.Property<string>("Password")
                        .HasColumnType("character varying")
                        .HasColumnName("password");

                    b.Property<string>("Phone")
                        .HasColumnType("character varying")
                        .HasColumnName("phone");

                    b.Property<string>("Source")
                        .HasColumnType("character varying")
                        .HasColumnName("source");

                    b.Property<string>("Text")
                        .HasColumnType("character varying")
                        .HasColumnName("text");

                    b.HasKey("IdS")
                        .HasName("Senders_pkey");

                    b.ToTable("Senders", "SendDB");
                });
#pragma warning restore 612, 618
        }
    }
}
