using Pledgewise.Common.Web.Model.Common;
using Pledgewise.Common.Web.Model.Pledge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pledgewise.Common.Web.RequestResponse.Pledge
{
    public class GetPledgesWebResponseDTO
    {
        public PaginatedDataWebDTO<PledgeWebDTO>? Pledges { get; set; }
    }
}