using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.Files
{
    public class UploadFileDTO
    {
        public IFormFile File { get; set; }
    }
}
