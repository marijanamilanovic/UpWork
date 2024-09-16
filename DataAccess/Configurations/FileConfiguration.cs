using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    public class FileConfiguration : IEntityTypeConfiguration<Domain.File>
    {
        public void Configure(EntityTypeBuilder<Domain.File> builder)
        {
            builder.Property(x => x.Path)
                   .IsRequired()
                   .HasMaxLength(250);

            builder.Property(x => x.Extension)
                   .IsRequired()
                   .HasMaxLength(10);

            builder.Property(x => x.Size)
                   .IsRequired();
        }
    }
}
