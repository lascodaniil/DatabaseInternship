using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ServerPart.DatabaseFirst.DBFirst
{
    public partial class LanguageAPIContext : DbContext
    {
        public LanguageAPIContext()
        {
        }

        public LanguageAPIContext(DbContextOptions<LanguageAPIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Courses> Courses { get; set; }
        public virtual DbSet<Languages> Languages { get; set; }
        public virtual DbSet<Levels> Levels { get; set; }
        public virtual DbSet<StudentCourses> StudentCourses { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<TeacherCourses> TeacherCourses { get; set; }
        public virtual DbSet<TeacherLanguages> TeacherLanguages { get; set; }
        public virtual DbSet<Teachers> Teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("data source=DESKTOP-I2JBLKP; Initial Catalog=LanguageAPI;  Trusted_Connection=True; ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Courses>(entity =>
            {
                entity.HasKey(e => e.CourseId);

                entity.HasIndex(e => e.LevelId);

                entity.Property(e => e.Language)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.Level)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.LevelId);
            });

            modelBuilder.Entity<Languages>(entity =>
            {
                entity.HasKey(e => e.LanguageId);

                entity.Property(e => e.Language)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Levels>(entity =>
            {
                entity.HasKey(e => e.LevelId);

                entity.Property(e => e.LevelCourse)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<StudentCourses>(entity =>
            {
                entity.HasKey(e => e.StudentCourseId);

                entity.HasIndex(e => e.CourseId);

                entity.HasIndex(e => e.StudentId);

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.StudentCourses)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentCourses)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Students>(entity =>
            {
                entity.HasKey(e => e.StudentId);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.RegistrationDate).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TeacherCourses>(entity =>
            {
                entity.HasIndex(e => e.CourseId);

                entity.HasIndex(e => e.TeacherId);

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.TeacherCourses)
                    .HasForeignKey(d => d.CourseId);

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.TeacherCourses)
                    .HasForeignKey(d => d.TeacherId);
            });

            modelBuilder.Entity<TeacherLanguages>(entity =>
            {
                entity.HasIndex(e => e.LanguageId);

                entity.HasIndex(e => e.TeacherId);

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.TeacherLanguages)
                    .HasForeignKey(d => d.LanguageId);

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.TeacherLanguages)
                    .HasForeignKey(d => d.TeacherId);
            });

            modelBuilder.Entity<Teachers>(entity =>
            {
                entity.HasKey(e => e.TeacherId);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(255);
            });
        }
    }
}
