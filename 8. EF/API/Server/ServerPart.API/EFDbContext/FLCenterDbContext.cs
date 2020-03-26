using Microsoft.EntityFrameworkCore;
using ServerPart.Domain.Entities;
using ServerPart.EF.ConfigFluentAPI;
using ServerPart.EFMapping.ConfigFluentAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerPart.API.EFDbContext
{
    public class FLCenterDbContext : DbContext
    {
        private const string connectionString = @"data source=DESKTOP-I2JBLKP; Initial Catalog=LanguageAPI;  Trusted_Connection=True; ";



        public FLCenterDbContext() { }
        public FLCenterDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Level> CourseLevels { get; set; }
        public DbSet<Languages> Languages { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<TeacherCourse> TeacherCourses { get; set; }
        public DbSet<TeacherLanguages> TeacherLanguages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentConfig());
            modelBuilder.ApplyConfiguration(new TeacherConfig());
            modelBuilder.ApplyConfiguration(new LanguageConfig());
            modelBuilder.ApplyConfiguration(new LevelConfig());
            modelBuilder.ApplyConfiguration(new CourseConfig());
            modelBuilder.ApplyConfiguration(new StudentCourseConfig());
            modelBuilder.ApplyConfiguration(new TeacherLanguagesConfig());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
