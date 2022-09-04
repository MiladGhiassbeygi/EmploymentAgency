using Domain.WriteModel;

namespace Application.Contracts.Persistence.JobContract
{
    public interface IJobCommissionRepository
    {
        Task<JobCommission> CreateJobCommissionAsync(JobCommission jobCommission);
        Task<JobCommission> GetJobCommissionByIdAsync(long id);
        Task<JobCommission> UpdateJobCommissionAsync(JobCommission jobCommission);
        Task<JobCommission> DeleteJobCommissionByIdAsync(long id);
        Task<List<JobCommission>> GetAll();
    }
}
