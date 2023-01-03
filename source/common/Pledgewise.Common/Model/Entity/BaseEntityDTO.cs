using Pledgewise.Common.Model.Entity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pledgewise.Common.Model.Entity
{
    public class BaseEntityDTO
    {
        public long Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public EntityTypeEnum Type { get; set; }

        public string CreatedByUserId { get; set; }

        public DateTime CreatedOn { get; set; }

        public int PledgesCount { get; set; }

        public int FullfiledPledgesCount { get; set; }

        public int FailedPledgesCount { get; set; }

        public int PendingPledgesCount { get; set; }

        public int DelayedPledgesCount { get; set; }
    }
}