using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.ReadModel
{
    public class WorkExperience
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        public string Id { get; set; }

        [BsonElement("workExperienceId")]
        public int WorkExperienceId { get; set; }

        [BsonElement("jobTitle")]
        public string JobTitle { get; set; }

        [BsonElement("hoursOfWork")]
        public int HoursOfWork { get; set; }

        [BsonElement("startDate")]
        public DateTime StartDate { get; set; }

        [BsonElement("endDate")]
        public DateTime EndDate { get; set; }

        [BsonElement("salaryPaid")]
        public decimal SalaryPaid { get; set; }

        [BsonElement("typeOfCooperation")]
        public string TypeOfCooperation { get; set; }

        [BsonElement("hireCompanies")]
        public string HireCompanies { get; set; }

        [BsonElement("skills")]
        public short[] Skills { get; set; }

        [BsonElement("jobSeekerId")]
        public long JobSeekerId { get; set; }
    }
}
