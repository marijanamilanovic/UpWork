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
    public class JobSkillConfiguration : IEntityTypeConfiguration<JobSkill>
    {
        public void Configure(EntityTypeBuilder<JobSkill> builder)
        {
           builder.HasKey(x => new { x.JobId, x.SkillId });

            builder.HasOne(x => x.Job).WithMany(x => x.Skills).HasForeignKey(x => x.JobId);

            builder.HasOne(x => x.Skill).WithMany(x => x.Jobs).HasForeignKey(x => x.SkillId);
        }
    }
}
