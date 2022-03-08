using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Enums
{
    public enum  OrderStatus
    {
        Pending = 1,
        Accepted,
        Packaging,
        InCargo,
        OnCourrier,
        Delivered,
        Rejected,
        Canceled,
    }
}
