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
    public class UserProfilePortfolioConfiguration : IEntityTypeConfiguration<UserProfilePortfolio>
    {
        public void Configure(EntityTypeBuilder<UserProfilePortfolio> builder)
        {
            builder.Property(x => x.Title)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(x => x.Role)
                   .HasMaxLength(50);

            builder.Property(x => x.Description)
                   .IsRequired();

            builder.HasOne(x => x.UserProfile).WithMany(x => x.Portfolios).HasForeignKey(x => x.UserProfileId);
        }
    }
}
