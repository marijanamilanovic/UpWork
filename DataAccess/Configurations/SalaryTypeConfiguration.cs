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
    public class SalaryTypeConfiguration : IEntityTypeConfiguration<SalaryType>
    {
        public void Configure(EntityTypeBuilder<SalaryType> builder)
        {
            builder.Property(x => x.Type)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.HasIndex(x => x.Type)
                   .IsUnique();
        }
    }
}
