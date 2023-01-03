using Pledgewise.Common.Model.Pledge.Enum;
using Pledgewise.Common.Model.PledgeUpdate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pledgewise.Common.Model.Pledge
{
    public class BasePledgeDTO<TPledgeUpdate> where TPledgeUpdate : BasePledgeUpdateDTO
    {
        public long Id { get; set; }

        public long EntityId { get; set; }

        public string CreatedByUserId { get; set; }

        public PledgeStatusEnum Status { get; set; }

        public DateTime CreatedOn { get; set; }

        public List<TPledgeUpdate> PledgeUpdates { get; set; }
    }
}