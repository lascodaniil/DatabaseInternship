using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerPart.Domain.Entities;

namespace ServerPart.EF.ConfigFluentAPI
{
    public class LevelConfig : IEntityTypeConfiguration<Level>
    {
        public void Configure(EntityTypeBuilder<Level> entity)
        {

            entity.Property(p => p.Id).HasColumnName("LevelId"); // de sters
            entity.Property(p => p.LevelCourse).IsRequired().HasMaxLength(255);
        }
    }



}
