using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace COMP2001_WebProj.Models
{
    public partial class COMP2001_JSandilandsContext : DbContext
    {
        public COMP2001_JSandilandsContext()
        {
        }

        public COMP2001_JSandilandsContext(DbContextOptions<COMP2001_JSandilandsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Password> Passwords { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=socem1.uopnet.plymouth.ac.uk;Database=COMP2001_JSandilands;User Id=JSandilands;Password=RscT224+");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Password>(entity =>
            {
                entity.HasKey(e => new { e.Userid, e.DateChanged })
                    .HasName("PK_password");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.Property(e => e.DateChanged)
                    .HasColumnType("date")
                    .HasColumnName("date_changed");

                entity.Property(e => e.Passw)
                    .IsRequired()
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .HasColumnName("passw");
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.HasKey(e => new { e.Userid, e.DateTime })
                    .HasName("PK_session");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.Property(e => e.DateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("date_time");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Userid)
                    .ValueGeneratedNever()
                    .HasColumnName("userid");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(254)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Firstn)
                    .IsRequired()
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .HasColumnName("firstn");

                entity.Property(e => e.Lastn)
                    .IsRequired()
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .HasColumnName("lastn");

                entity.Property(e => e.Passw)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("passw");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
