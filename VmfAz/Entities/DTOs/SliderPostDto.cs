using Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class SliderPostDto : IDto
    { 
        public int Order { get; set; }
        public string RedirectURL { get; set; }
        public IFormFile File { get; set; }

    }
}
