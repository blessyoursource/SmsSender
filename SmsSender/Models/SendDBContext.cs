using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SmsSender.Models
{
    public partial class SendDBContext : DbContext
    {
        public SendDBContext()
        {
        }

        public SendDBContext(DbContextOptions<SendDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Response> Responses { get; set; }
        public virtual DbSet<Sender> Senders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Database=SendDB;Username=postgres;Password=root");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Response>(entity =>
            {
                entity.HasKey(e => e.IdR)
                    .HasName("Response_pkey");

                entity.ToTable("Response", "SendDB");

                entity.Property(e => e.IdR)
                    .ValueGeneratedNever()
                    .HasColumnName("idR");

                entity.Property(e => e.Result).HasColumnType("character varying");
            });

            modelBuilder.Entity<Sender>(entity =>
            {
                entity.HasKey(e => e.IdS)
                    .HasName("Senders_pkey");

                entity.ToTable("Senders", "SendDB");

                entity.Property(e => e.IdS)
                    .HasColumnName("idS")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Login)
                    .HasColumnType("character varying")
                    .HasColumnName("login");

                entity.Property(e => e.Password)
                    .HasColumnType("character varying")
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .HasColumnType("character varying")
                    .HasColumnName("phone");

                entity.Property(e => e.Source)
                    .HasColumnType("character varying")
                    .HasColumnName("source");

                entity.Property(e => e.Text)
                    .HasColumnType("character varying")
                    .HasColumnName("text");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
