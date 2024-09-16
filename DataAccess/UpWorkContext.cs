using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UpWorkContext : DbContext
    {
        private readonly string _connectionString;

        public UpWorkContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        public UpWorkContext()
        {
            _connectionString = "Data Source=;Initial Catalog=UpWork;TrustServerCertificate=true;Integrated security=true";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString).UseLazyLoadingProxies();

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            IEnumerable<EntityEntry> entries = this.ChangeTracker.Entries();

            foreach (EntityEntry entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    if (entry.Entity is Entity e)
                    {
                        e.IsActive = true;
                        e.CreatedAt = DateTime.UtcNow;
                    }
                }
                if (entry.State == EntityState.Modified)
                {
                    if (entry.Entity is Entity e)
                    {
                        e.UpdatedAt = DateTime.UtcNow;
                    }
                }
            }

            return base.SaveChanges();
        }

        public DbSet<AuditLog> AuditLogs { get; set; }

        public DbSet<ErrorLog> ErrorLogs { get; set; }

        public DbSet<Skill> Skills { get; set; }

        public DbSet<Experience> Experiences { get; set; }

        public DbSet<Domain.File> Files { get; set; }

        public DbSet<Language> Languages { get; set; }
        
        public DbSet<WorkHour> WorkHours { get; set; }

        public DbSet<SalaryType> SalaryTypes { get; set; }

        public DbSet<LanguageProficiencyLevel> LanguageProficiencyLevels { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserUseCase> UserUseCases { get; set; }

        public DbSet<UserEducation> UserEducations { get; set; }

        public DbSet<UserLanguage> UserLanguages { get; set; }

        public DbSet<UserWorkExperience> UserWorkExperiences { get; set; }

        public DbSet<UserProfile> UserProfiles { get; set; }

        public DbSet<UserProfilePortfolio> UserProfilePortfolios { get; set; }

        public DbSet<UserProfileSkill> UserProfileSkills { get; set; }

        public DbSet<UserProfilePortfolioSkill> UserProfilePortfolioSkills { get; set; }

        public DbSet<Job> Jobs { get; set; }

        public DbSet<JobSkill> JobSkills { get; set; }

        public DbSet<Proposal> Proposals { get; set; }

        public DbSet<SavedJob> SavedJobs { get; set; }
    }
}
