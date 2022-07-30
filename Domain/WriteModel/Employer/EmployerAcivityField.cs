using Domain.WriteModel.Common;
using System;
using System.Collections.Generic;

namespace Domain.WriteModel
{
    public partial class EmployerAcivityField : BaseEntity<byte>
    {
        public EmployerAcivityField()
        {
            EmployerDetails = new HashSet<Employer>();
        }
        public byte Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Employer> EmployerDetails { get; set; }
    }
}
