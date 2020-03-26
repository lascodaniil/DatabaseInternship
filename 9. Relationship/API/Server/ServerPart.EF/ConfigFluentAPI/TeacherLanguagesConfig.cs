using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerPart.Domain.Entities;

namespace ServerPart.EF.ConfigFluentAPI
{
    public class TeacherLanguagesConfig : IEntityTypeConfiguration<TeacherLanguages>
    {
        public void Configure(EntityTypeBuilder<TeacherLanguages> entity)
        {
            entity.Property(p => p.Id).HasColumnName("TeacherLanguagesId");
            entity.HasOne(p => p.Language).WithMany(p => p.TeacherLanguages).HasForeignKey(p=>p.LanguageId).OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(p => p.Teacher).WithMany(p => p.TeacherLanguages).HasForeignKey(p=>p.TeacherId).OnDelete(DeleteBehavior.Cascade);

        }
    }

}
