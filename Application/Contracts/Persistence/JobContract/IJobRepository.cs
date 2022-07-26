using Domain.WriteModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Persistence
{
    public interface IJobRepository
    {
        Task<Job> CreateJobAsync(Job job);
        Task<Job> GetJobByIdAsync(int id);
        Task<Job> GetJobByTitleAsync(string title);
        Task<Job> UpdateJobAsync(Job job);
        Task<Job> DeleteJobByIdAsync(int id);
        Task<List<Job>> GetAll();
    }
}
