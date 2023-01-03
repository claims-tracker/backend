using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pledgewise.Common.Model.Entity
{
    public class BaseGetEntity : BaseEntity
    {
        public long Id { get; set; }

        public string CreatedByUserId { get; set; }

        public DateTime CreatedOn { get; set; }

        public int PledgesCount { get; set; }

        public int FullfiledPledgesCount { get; set; }

        public int FailedPledgesCount { get; set; }

        public int PendingPledgesCount { get; set; }

        public int DelayedPledgesCount { get; set; }
    }
}