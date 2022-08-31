using Domain.WriteModel.Common;

namespace Domain.WriteModel
{
    public partial class EmployerAcivityField : BaseEntity<byte>
    {
        public EmployerAcivityField()
        {
            EmployerDetails = new HashSet<Employer>();
        }
        public string Title { get; set; }
        public int DefinerId { get; set; }
        public User.User Definer { get; set; }
        public virtual ICollection<Employer> EmployerDetails { get; set; }
    }
}
