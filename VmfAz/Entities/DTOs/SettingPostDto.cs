using Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class SettingPostDto : IDto
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public IFormFile File { get; set; }
    }
}
