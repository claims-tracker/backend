using Pledgewise.Common.Web.Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pledgewise.Common.Web.Model.Base
{
    public class BasePaginatedWebRequest<PropertyNameEnumT> : BaseWebRequest where PropertyNameEnumT : struct, IConvertible
    {
        [Range(1, 100, ErrorMessage = "Count must be between 1 and 100")]
        public int Count { get; set; } = 25;

        [Range(1, int.MaxValue, ErrorMessage = "Page size must be between 1 and Int.MaxValue")]
        public int Page { get; set; } = 1;

        public IEnumerable<SortWebDTO<PropertyNameEnumT>>? Sort { get; set; }

        public IEnumerable<FilterWebDTO<PropertyNameEnumT>>? Filter { get; set; }
    }
}
