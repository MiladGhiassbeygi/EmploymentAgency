using Domain.WriteModel;

namespace Application.Contracts.Persistence
{
    public interface IJobRepository
    {
        Task<Job> CreateJobAsync(Job job);
        Task<Job> GetJobByIdAsync(long id);//this was int
        Task<Job> GetJobByIdAggregateAsync(long id);//this was int
        Task<Job> GetJobAggregateByIdAsync(long id);
        Task<Job> GetJobByTitleAsync(string title);
        Task<Job> UpdateJobAsync(Job job);
        Task<Job> DeleteJobByIdAsync(long id); //this was int
        Task<Job> DeleteJobAsync(Job job);
        Task<List<Job>> GetAll();
    }
}
