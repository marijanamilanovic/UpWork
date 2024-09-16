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
    public class AuditLogConfiguration : IEntityTypeConfiguration<AuditLog>
    {
        public void Configure(EntityTypeBuilder<AuditLog> builder)
        {
            builder.Property(x => x.PerformedBy)
                  .IsRequired()
                  .HasMaxLength(150);

            builder.Property(x => x.Action)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasIndex(x => new { x.PerformedBy, x.Action, x.ExecutedAt })
                   .IncludeProperties(x => x.Data);
        }
    }
}
