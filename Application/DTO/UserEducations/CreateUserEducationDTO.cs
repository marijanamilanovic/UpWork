﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.UserEducations
{
    public class CreateUserEducationDTO
    {
        public string School { get; set; }

        public string Degree { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}
