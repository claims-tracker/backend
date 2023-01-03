using Pledgewise.Common.Web.Model.Common;
using Pledgewise.Common.Web.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pledgewise.Common.Web.RequestResponse.Entity
{
    public class GetEntitiesWebResponseDTO
    {
        public PaginatedDataWebDTO<EntityWebDTO>? Entities { get; set; }
    }
}
