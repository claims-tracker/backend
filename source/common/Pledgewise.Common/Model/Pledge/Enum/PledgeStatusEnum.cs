using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pledgewise.Common.Model.Pledge.Enum
{
    public enum PledgeStatusEnum
    {
        Pending = 1,
        Fulfilled = 2,
        Failed = 4,
        Late = 8,
    }
}
