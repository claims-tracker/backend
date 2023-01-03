using Pledgewise.Common.Model.Pledge.Enum;
using Pledgewise.Common.Model.PledgeUpdate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pledgewise.Common.Model.Pledge
{
    public class BasePledgeDTO
    {
        public long EntityId { get; set; }

        public string CreatedByUserId { get; set; }

        public PledgeStatusEnum Status { get; set; }
    }
}