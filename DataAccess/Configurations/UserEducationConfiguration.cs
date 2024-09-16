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
    public class UserEducationConfiguration : IEntityTypeConfiguration<UserEducation>
    {
        public void Configure(EntityTypeBuilder<UserEducation> builder)
        {
            builder.Property(x => x.School)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.StartDate)
                   .IsRequired();


            builder.HasOne(x => x.User).WithMany(x => x.Educations).HasForeignKey(x => x.UserId);
        }
    }
}
