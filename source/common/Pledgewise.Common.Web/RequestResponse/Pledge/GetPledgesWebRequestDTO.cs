using Pledgewise.Common.Model.Entity.Enum;
using Pledgewise.Common.Model.Pledge.Enum;
using Pledgewise.Common.Web.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pledgewise.Common.Web.RequestResponse.Pledge
{
    public class GetPledgesWebRequestDTO : BasePaginatedWebRequest<PledgePropertyNameEnum>
    {
    }
}