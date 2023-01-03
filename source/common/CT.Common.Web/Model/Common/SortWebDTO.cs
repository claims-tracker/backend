using CT.Common.Web.Model.Common.Enum;
using System;

namespace CT.Common.Web.Model.Common
{
    public class SortWebDTO<PropertyNameEnumT> where PropertyNameEnumT : struct, IConvertible
    {
        public PropertyNameEnumT Field { get; set; }

        public OrderByEnum Order { get; set; }
    }
}