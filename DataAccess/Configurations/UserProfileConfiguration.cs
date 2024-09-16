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
    public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.Property(x => x.Title)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.Description)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.Property(x => x.SalaryPerHour)
                   .IsRequired();

            builder.HasOne(x => x.User).WithMany(x => x.Profiles).HasForeignKey(x => x.UserId);
        }
    }
}
