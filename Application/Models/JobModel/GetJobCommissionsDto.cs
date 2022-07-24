using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.JobModel
{
    public class GetJobCommissionsDto
    {
        public bool IsFixed { get; set; } = false;
        public int Value { get; set; }
        public long JobId { get; set; }
    }
}
