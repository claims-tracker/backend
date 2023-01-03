using Pledgewise.Common.Web.Model.Base;
using Pledgewise.Common.Web.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pledgewise.Common.Web.RequestResponse.Entity
{
    public class PutEntitiesWebRequestDTO : BaseWebRequest
    {
        public List<PutEntityWebDTO> Entities { get; set; }
    }
}