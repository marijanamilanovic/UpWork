using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class UserWorkExperience 
    {
        public int Id { get; set; }

        public string CompanyName { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string Position { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string Description { get; set; }

        public int UserId { get; set; }


        public virtual User User { get; set; }
    }
}
