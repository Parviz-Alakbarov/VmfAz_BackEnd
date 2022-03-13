using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Slider : IEntity
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public string RedirectURL { get; set; }
        public string Image { get; set; }
    }
}
