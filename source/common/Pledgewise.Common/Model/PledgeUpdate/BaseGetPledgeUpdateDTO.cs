using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pledgewise.Common.Model.PledgeUpdate
{
    public class BaseGetPledgeUpdateDTO : BasePledgeUpdateDTO
    {
        public long Id { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}