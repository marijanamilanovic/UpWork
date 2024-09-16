using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.Users
{
    public class SearchUser : SearchEntityDTO
    {
        public string FullName { get; set; }

        public string Email { get; set; }

        public int? MinConnects { get; set; }

        public int? MaxConnects { get; set; }
    }
}
