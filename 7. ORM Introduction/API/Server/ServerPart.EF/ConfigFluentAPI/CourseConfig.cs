using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerPart.Domain.Entities;

namespace ServerPart.EF.ConfigFluentAPI
{
    public class CourseConfig : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> entity)
        {
            entity.Property(p => p.Id).HasColumnName("CourseId");
            entity.Property(p => p.Language).IsRequired().HasMaxLength(255);
            entity.Property(p => p.StartDate).ValueGeneratedOnAddOrUpdate().HasColumnType("date");
            entity.Property(p => p.Title).IsRequired().HasMaxLength(255);
        }
    }



}
