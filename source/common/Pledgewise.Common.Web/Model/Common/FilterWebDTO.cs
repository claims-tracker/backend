using Pledgewise.Common.Web.Model.Common.Enum;
using System;
using System.Collections.Generic;

namespace Pledgewise.Common.Web.Model.Common
{
    public class FilterWebDTO<PropertyNameEnumT> where PropertyNameEnumT : struct, IConvertible
    {
        public PropertyNameEnumT Field { get; set; }

        public FilterOperatorEnum Operator { get; set; }

        public string? Value { get; set; }

        public FilterLogicEnum Logic { get; set; } = FilterLogicEnum.And;

        public IEnumerable<FilterWebDTO<PropertyNameEnumT>>? Filters { get; set; }
    }
}