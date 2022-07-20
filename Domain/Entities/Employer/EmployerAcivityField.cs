using Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class EmployerAcivityField : BaseEntity<byte>
    {
        public EmployerAcivityField()
        {
            EmployerDetails = new HashSet<Employer>();
        }

        public string Title { get; set; }

        public virtual ICollection<Employer> EmployerDetails { get; set; }
    }
}
