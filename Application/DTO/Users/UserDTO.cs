using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.Users
{
    public class UserDTO : EntityDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public int Connects { get; set; }

        public string ProfilePhoto { get; set; }
    }
}
