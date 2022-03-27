using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.BrandDTOs
{
    public  class BrandDetailDto : IDto 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PosterImage { get; set; }
        public string Image { get; set; }
    }
}
