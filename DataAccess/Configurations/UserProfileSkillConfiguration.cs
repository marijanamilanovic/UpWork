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
    public class UserProfileSkillConfiguration : IEntityTypeConfiguration<UserProfileSkill>
    {
        public void Configure(EntityTypeBuilder<UserProfileSkill> builder)
        {
            builder.HasKey(x => new { x.UserProfileId, x.SkillId });

            builder.HasOne(x => x.UserProfile).WithMany(x => x.Skills).HasForeignKey(x => x.UserProfileId);

            builder.HasOne(x => x.Skill).WithMany(x => x.UserProfiles).HasForeignKey(x => x.SkillId);
        }
    }
}
