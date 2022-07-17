using Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.Entities.Employer
{
    public partial class EmployerAcivityField : BaseEntity<byte>
    {
        public EmployerAcivityField()
        {
            EmployerDetails = new HashSet<EmployerDetails>();
        }

        public string Title { get; set; }

        public virtual ICollection<EmployerDetails> EmployerDetails { get; set; }
    }
}
