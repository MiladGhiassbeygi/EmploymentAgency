using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.ReadModel
{
    public  class Job 
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        public string Id { get; set; }

        [BsonElement("jobId")]
        public long JobId { get; set; }

        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("hoursOfWork")]
        public int HoursOfWork { get; set; }

        [BsonElement("salaryMin")]
        public decimal SalaryMin { get; set; }

        [BsonElement("salaryMax")]
        public decimal SalaryMax { get; set; }

        [BsonElement("annualLeave")]
        public byte AnnualLeave { get; set; }

        [BsonElement("isFixed")]
        public bool IsFixed { get; set; }

        [BsonElement("exactAmountRecived")]
        public decimal ExactAmountRecived { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("essentialSkills")]
        public short[] EssentialSkills { get; set; }

        [BsonElement("unnecessarySkills")]
        public short[] UnnecessarySkills { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("hireCompanies")]
        public string HireCompanies { get; set; }

        [BsonElement("employerId")]
        public long EmployerId { get; set; }
        [BsonElement("definerId")]
        public long DefinerId { get; set; }


    }
}
