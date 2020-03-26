using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerPart.Domain.Entities;

namespace ServerPart.EF.ConfigFluentAPI
{
    public class LanguageConfig : IEntityTypeConfiguration<Languages>
    {
        public void Configure(EntityTypeBuilder<Languages> entity)
        {

            entity.Property(p => p.Id).HasColumnName("LanguageId");
            entity.Property(p => p.Language).IsRequired().HasMaxLength(255);
        }
    }
}
