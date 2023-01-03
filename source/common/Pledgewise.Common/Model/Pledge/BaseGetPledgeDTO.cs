using Pledgewise.Common.Model.PledgeUpdate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pledgewise.Common.Model.Pledge
{
    public class BaseGetPledgeDTO<TPledgeUpdate> : BasePledgeDTO where TPledgeUpdate : BasePledgeUpdateDTO
    {
        public long Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public List<TPledgeUpdate> PledgeUpdates { get; set; }
    }
}