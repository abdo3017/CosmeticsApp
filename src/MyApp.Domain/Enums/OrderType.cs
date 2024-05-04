using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Enums
{
    public enum OrderStatus
    {
        Open = 0,
        Confirmed = 1,
        Canceled = 2,
        Delivered = 3,
        Closed = 4
    }
}
