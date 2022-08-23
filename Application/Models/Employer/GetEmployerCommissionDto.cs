using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Employer
{
    public class GetEmployerCommissionDto
    {
        public bool IsFixed { get; set; } = false;
        public int Value { get; set; }
        public long EmployerId { get; set; }
    }
}
