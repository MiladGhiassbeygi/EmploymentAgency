using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ReadModel
{
    public class EducationalBackground
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        public string Id { get; set; }

        [BsonElement("educationalBackgroundId")]
        public int EducationalBackgroundId { get; set; }

        [BsonElement("school")]
        public string School { get; set; }

        [BsonElement("degree")]
        public string Degree { get; set; }

        [BsonElement("fieldOfStudy")]
        public string FieldOfStudy { get; set; }

        [BsonElement("startDate")]
        public DateTime StartDate { get; set; }

        [BsonElement("endDate")]
        public DateTime EndDate { get; set; }

        [BsonElement("jobSeekerId")]
        public long JobSeekerId { get; set; }
    }
}
