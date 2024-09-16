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
    public class UserProfilePortfolioSkillConfiguration : IEntityTypeConfiguration<UserProfilePortfolioSkill>
    {
        public void Configure(EntityTypeBuilder<UserProfilePortfolioSkill> builder)
        {
            builder.HasKey(x => new { x.UserProfilePortfolioId, x.SkillId });

            builder.HasOne(x => x.UserProfilePortfolio).WithMany(x => x.Skills).HasForeignKey(x => x.UserProfilePortfolioId);

            builder.HasOne(x => x.Skill).WithMany(x => x.UserProfilePortfolios).HasForeignKey(x => x.SkillId);
        }
    }
}
