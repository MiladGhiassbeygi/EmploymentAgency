using Domain.ReadModel;
using Domain.WriteModel.Common;
using Domain.WriteModel.User;

namespace Domain.WriteModel
{
    public partial class JobSeeker : BaseEntity<long>
    {
        public JobSeeker()
        {
            SuccessedContract = new HashSet<SuccessedContract>();
        }
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CountryId { get; set; }
        public string Email { get; set; }
        public string LinkedinAddress { get; set; }
        public string ResumeFilePath { get; set; }
        public int DefinerId { get; set; }
        public int EducationalBackgroundId { get; set; }
        public int WorkExperienceId { get; set; }




        public virtual User.User Definer { get; set; }
        public virtual Country Country { get; set; }
        public virtual ICollection<JobSeekerEssentialSkills> JobSeekerEssentialSkills { get; set; }
        public virtual ICollection<JobSeekerUnnessecarySkills> JobSeekerUnnecessarySkills { get; set; }
        public virtual ICollection<WorkExperience> WorkExperiences { get; set; }
        public virtual ICollection<EducationalBackground> EducationalBackgrounds { get; set; }
        public virtual ICollection<SuccessedContract> SuccessedContract { get; set; }
    }
}
