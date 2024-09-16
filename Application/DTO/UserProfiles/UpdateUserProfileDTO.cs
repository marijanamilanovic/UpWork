using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.UserProfiles
{
    public class UpdateUserProfileDTO : UpdateEntityDTO
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public int SalaryPerHour { get; set; }
    }
}
