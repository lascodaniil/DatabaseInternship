using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerPart.Domain.Entities;

namespace ServerPart.EF.ConfigFluentAPI
{
    public class StudentCourseConfig : IEntityTypeConfiguration<StudentCourse>
    {
        public void Configure(EntityTypeBuilder<StudentCourse> entity)
        {

            entity.Property(p => p.Id).HasColumnName("StudentCourseId");
            entity.HasOne(p => p.Student).WithMany(p => p.StudentCourse);
            entity.HasOne(p => p.Course).WithMany(p => p.StudentCourse);
        }
    }

}
