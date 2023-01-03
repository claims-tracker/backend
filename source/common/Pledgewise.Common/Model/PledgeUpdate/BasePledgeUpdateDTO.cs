using Pledgewise.Common.Model.Pledge.Enum;
using Pledgewise.Common.Model.PledgeUpdate.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pledgewise.Common.Model.PledgeUpdate
{
    public class BasePledgeUpdateDTO
    {
        public long PledgeId { get; set; }

        public string CreatedByUserId { get; set; }

        public PledgeUpdateTypeEnum Type { get; set; }
    }
}