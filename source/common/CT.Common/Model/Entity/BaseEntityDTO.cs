using CT.Common.Model.Entity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CT.Common.Model.Entity
{
    public class BaseEntityDTO
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public EntityTypeEnum Type { get; set; }

        public string CreatedByUserId { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
