
namespace Application.BackgroundWorker.Common.Events
{
    public class JobSeekerAdded
    {
        public long JobSeekerId { get; set; }
        public short[] SkillIds { get; set; }
    }
}
