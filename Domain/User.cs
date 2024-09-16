using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class User : Entity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int Connects { get; set; }

        public int ProfilePhotoId { get; set; }


        public virtual File ProfilePhoto { get; set; }

        public virtual ICollection<UserUseCase> UseCases { get; set; } = new HashSet<UserUseCase>();

        public virtual ICollection<Job> Jobs { get; set; } = new HashSet<Job>();

        public virtual ICollection<UserEducation> Educations { get; set; } = new HashSet<UserEducation>();

        public virtual ICollection<UserLanguage> Languages { get; set; } = new HashSet<UserLanguage>();

        public virtual ICollection<UserWorkExperience> WorkExperiences { get; set; } = new HashSet<UserWorkExperience>();

        public virtual ICollection<UserProfile> Profiles { get; set; } = new HashSet<UserProfile>();

        public virtual ICollection<Proposal> Proposals { get; set; } = new HashSet<Proposal>();

        public virtual ICollection<SavedJob> SavedJobs { get; set; } = new HashSet<SavedJob>();
    }   
}
