using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerPart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServerPart.EF.ConfigFluentAPI
{
    public class TeacherConfig : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> entity)
        {
            entity.Property(p => p.Id).HasColumnName("TeacherId");
            entity.Property(p => p.Email).IsRequired().HasMaxLength(64);
            entity.Property(p => p.FirstName).IsRequired().HasMaxLength(255);
            entity.Property(p => p.LastName).IsRequired().HasMaxLength(255);

        }
    }
}
