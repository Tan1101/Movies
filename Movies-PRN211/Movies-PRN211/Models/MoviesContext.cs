using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Movies_PRN211.Models
{
    public partial class MoviesContext : DbContext
    {
        public MoviesContext()
        {
        }

        public MoviesContext(DbContextOptions<MoviesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Cmt> Cmts { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<Movie> Movies { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json").Build();
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(config.GetValue<string>
                    ("ConnectionStrings:DBContext"));
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.Gmail)
                    .HasName("PK__Account__493D0C0B3FD94EDB");

                entity.ToTable("Account");

                entity.Property(e => e.Gmail)
                    .HasMaxLength(100)
                    .HasColumnName("gmail");

                entity.Property(e => e.AccStatus).HasColumnName("accStatus");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .HasColumnName("password");

                entity.Property(e => e.Role)
                    .HasMaxLength(10)
                    .HasColumnName("role");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CaId)
                    .HasName("PK__Categori__21BDC4FE5DB973E9");

                entity.Property(e => e.CaId).HasColumnName("caID");

                entity.Property(e => e.CaName)
                    .HasMaxLength(200)
                    .HasColumnName("caName");
            });

            modelBuilder.Entity<Cmt>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("cmt");

                entity.Property(e => e.Cid).HasColumnName("cid");

                entity.Property(e => e.Comment)
                    .HasMaxLength(100)
                    .HasColumnName("comment");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.HasOne(d => d.CidNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Cid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__cmt__cid__3C69FB99");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasKey(e => e.Cid)
                    .HasName("PK__Comment__D837D05F1525AA65");

                entity.ToTable("Comment");

                entity.Property(e => e.Cid).HasColumnName("cid");

                entity.Property(e => e.Comment1)
                    .HasMaxLength(100)
                    .HasColumnName("comment");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Comment__id__3A81B327");
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CaId).HasColumnName("caID");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Director)
                    .HasMaxLength(255)
                    .HasColumnName("director");

                entity.Property(e => e.Img)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("img");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.View).HasColumnName("view");

                entity.Property(e => e.Year).HasColumnName("year");

                entity.HasOne(d => d.Ca)
                    .WithMany(p => p.Movies)
                    .HasForeignKey(d => d.CaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Movies__caID__35BCFE0A");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
