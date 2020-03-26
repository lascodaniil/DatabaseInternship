using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.EFConfig
{
    public class UniversityConfig : IEntityTypeConfiguration<BaseUniversity>
    {
        public void Configure(EntityTypeBuilder<BaseUniversity> entity)
        {
            entity.Property(x => x.Rector).IsRowVersion();
        }
    }
}