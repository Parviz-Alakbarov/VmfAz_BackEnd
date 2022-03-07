using Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.BrandDTOs
{
    public class BrandPostDto :IDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile PosterImage { get; set; }
        public IFormFile Image { get; set; }
    }
}
