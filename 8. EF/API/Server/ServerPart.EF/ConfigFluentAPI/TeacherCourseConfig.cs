using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerPart.Domain.Entities;

namespace ServerPart.EF.ConfigFluentAPI
{
    public class TeacherCourseConfig : IEntityTypeConfiguration<TeacherCourse>
    {
        public void Configure(EntityTypeBuilder<TeacherCourse> entity)
        {
            //entity.Property(p => p.Id).HasColumnName("TeacherCourseId");
            //entity.hasone(p => p.course).withmany(p => p.teachercourse).hasforeignkey(p => p.courseid);
            //entity.hasone(p => p.teacher).withmany(p => p.teachercourse).hasforeignkey(p => p.teacherid);
        }
    }
}
