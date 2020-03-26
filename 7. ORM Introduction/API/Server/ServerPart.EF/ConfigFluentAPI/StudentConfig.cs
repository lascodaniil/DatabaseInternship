using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerPart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServerPart.EFMapping.ConfigFluentAPI
{
    public class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> entity)
        {

            entity.Property(p => p.Id).HasColumnName("StudentId");
            entity.Property(p => p.Email).HasMaxLength(64).IsRequired();
            entity.Property(p => p.FirstName).HasMaxLength(255).IsRequired();
            entity.Property(p => p.LastName).HasMaxLength(255).IsRequired();
            entity.Property(p => p.RegistrationDate).HasDefaultValueSql("GETDATE()");
        }
    }
}
