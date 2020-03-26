using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerPart.Domain.Entities;

namespace ServerPart.EF.ConfigFluentAPI
{
    public class TeacherCourseConfig : IEntityTypeConfiguration<TeacherCourse>
    {
        public void Configure(EntityTypeBuilder<TeacherCourse> entity)
        {
            entity.Property(p => p.Id).HasColumnName("TeacherCourseId");
            entity.HasOne(p => p.Course).WithMany(p => p.TeacherCourse).HasForeignKey(p => p.CourseId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(p => p.Teacher).WithMany(p => p.TeacherCourse).HasForeignKey(p => p.TeacherId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
