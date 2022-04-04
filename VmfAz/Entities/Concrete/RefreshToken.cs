using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class RefreshToken : IEntity
    {
        public Guid Id { get; set; }
        public string Token { get; set; }
        public int UserId { get; set; }
    }
}
