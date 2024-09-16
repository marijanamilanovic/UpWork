using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    public class LanguageProficiencyLevelConfiguration : IEntityTypeConfiguration<LanguageProficiencyLevel>
    {
        public void Configure(EntityTypeBuilder<LanguageProficiencyLevel> builder)
        {
            builder.Property(x => x.Level)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.HasIndex(x => x.Level)
                   .IsUnique();
        }
    }
}
