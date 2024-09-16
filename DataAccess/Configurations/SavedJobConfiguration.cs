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
    public class SavedJobConfiguration : IEntityTypeConfiguration<SavedJob>
    {
        public void Configure(EntityTypeBuilder<SavedJob> builder)
        {
            builder.HasKey(x => new { x.UserId, x.JobId });

            builder.HasOne(x => x.User).WithMany(x => x.SavedJobs).HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Job).WithMany(x => x.SavedByUsers).HasForeignKey(x => x.JobId);
        }
    }
}
