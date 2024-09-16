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
    public class ProposalConfiguration : IEntityTypeConfiguration<Proposal>
    {
        public void Configure(EntityTypeBuilder<Proposal> builder)
        {
            builder.Property(x => x.CoverLetter)
                   .IsRequired();

            builder.Property(x => x.ConnectsSpent)
                   .IsRequired();

            builder.HasIndex(x => new { x.CoverLetter, x.ConnectsSpent });

            builder.HasOne(x => x.User).WithMany(x => x.Proposals).HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Job).WithMany(x => x.Proposals).HasForeignKey(x => x.JobId);
        }
    }
}
