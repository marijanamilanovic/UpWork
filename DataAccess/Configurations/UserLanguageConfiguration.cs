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
    public class UserLanguageConfiguration : IEntityTypeConfiguration<UserLanguage>
    {
        public void Configure(EntityTypeBuilder<UserLanguage> builder)
        {
            builder.HasOne(x => x.User).WithMany(x => x.Languages).HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Language).WithMany(x => x.Users).HasForeignKey(x => x.LanguageId);

            builder.HasOne(x => x.LanguageProficiencyLevel).WithMany(x => x.Users).HasForeignKey(x => x.LanguageProficiencyLevelId);

            builder.HasKey(x => new
            {
                x.UserId,
                x.LanguageId
            });
        }
    }
}
