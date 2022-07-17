using Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.Entities.Area
{
    public partial class Country : BaseEntity<int>
    {
        public string Title { get; set; }
        public string PostalCode { get; set; }
        public string AreaCode { get; set; }
    }
}
