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
    public class UserWorkExperienceConfiguration : IEntityTypeConfiguration<UserWorkExperience>
    {
        public void Configure(EntityTypeBuilder<UserWorkExperience> builder)
        {
            builder.Property(x => x.CompanyName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.City)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.Country)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.Position)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.StartDate)
                   .IsRequired();


            builder.HasOne(x => x.User)
                   .WithMany(x => x.WorkExperiences)
                   .HasForeignKey(x => x.UserId);
        }
    }
}
