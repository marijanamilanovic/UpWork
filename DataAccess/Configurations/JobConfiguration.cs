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
    public class JobConfiguration : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            builder.Property(x => x.Title)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(x => x.Description)
                   .IsRequired();

            builder.Property(x => x.Location)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(x => x.Salary)
                   .IsRequired();

            builder.Property(x => x.MinRequiredConnects)
                   .IsRequired();

            builder.HasIndex(x => new { x.Title, x.Location, x.Description });


            builder.HasOne(x => x.SalaryType).WithMany(x => x.Jobs).HasForeignKey(x => x.SalaryTypeId);

            builder.HasOne(x => x.WorkHour).WithMany(x => x.Jobs).HasForeignKey(x => x.WorkHourId);

            builder.HasOne(x => x.Experience).WithMany(x => x.Jobs).HasForeignKey(x => x.ExperienceId);

            builder.HasOne(x => x.User).WithMany(x => x.Jobs).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
