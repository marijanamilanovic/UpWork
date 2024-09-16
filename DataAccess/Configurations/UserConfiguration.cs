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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.FirstName)
                  .IsRequired()
                  .HasMaxLength(50);

            builder.Property(x => x.LastName)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.Email)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.Password)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.Connects)
                   .IsRequired();

            builder.HasIndex(x => x.Email)
                   .IsUnique();


            builder.HasIndex(x => new
            {
                x.FirstName,
                x.LastName,
                x.Email,
            });

            builder.HasOne(x => x.ProfilePhoto).WithMany(x => x.Users).HasForeignKey(x => x.ProfilePhotoId);
        }
    }
}
