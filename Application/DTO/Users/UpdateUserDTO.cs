using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.Users
{
    public class UpdateUserDTO : UpdateEntityDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
    }
}
