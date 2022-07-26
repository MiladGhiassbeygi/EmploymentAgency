using Domain.WriteModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Persistence.JobContract
{
    public interface IJobCommissionRepository
    {
        Task<JobCommission> CreateJobCommissionAsync(JobCommission jobCommission);
        Task<JobCommission> GetJobCommissionByIdAsync(int id);
        Task<JobCommission> UpdateJobCommissionAsync(JobCommission jobCommission);
        Task<JobCommission> DeleteJobCommissionByIdAsync(int id);
        Task<List<JobCommission>> GetAll();
    }
}
