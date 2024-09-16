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
    public class WorkHourConfiguration : IEntityTypeConfiguration<WorkHour>
    {
        public void Configure(EntityTypeBuilder<WorkHour> builder)
        {
            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.HasIndex(x => x.Name)
                   .IsUnique();
        }
    }
}
