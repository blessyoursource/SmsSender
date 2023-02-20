using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SmsSender
{
    public partial class SendContext : DbContext
    {
        public SendContext()
        {
        }

        public SendContext(DbContextOptions<SendContext> options)
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
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Send;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Response>(entity =>
            {
                entity.HasKey(e => e.IdR)
                    .HasName("PK__Response__DC501A1EE6C6D4AC");

                entity.ToTable("Response");

                entity.Property(e => e.IdR)
                    .ValueGeneratedNever()
                    .HasColumnName("idR");

                entity.Property(e => e.Guid).HasColumnName("guid");

                entity.Property(e => e.Response1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("response");
            });

            modelBuilder.Entity<Sender>(entity =>
            {
                entity.HasKey(e => e.IdS)
                    .HasName("PK__tmp_ms_x__DC501A1D575D38BE");

                entity.ToTable("Sender");

                entity.Property(e => e.IdS).HasColumnName("idS");

                entity.Property(e => e.Login)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("login");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.Source)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("source");

                entity.Property(e => e.Text)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("text");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
