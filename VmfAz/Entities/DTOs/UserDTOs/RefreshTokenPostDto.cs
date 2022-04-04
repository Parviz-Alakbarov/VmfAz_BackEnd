using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.UserDTOs
{
    public class RefreshTokenPostDto
    {
        public int UserId { get; set; }
        public string Token { get; set; }
    }
}
