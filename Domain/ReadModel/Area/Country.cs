using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace Domain.ReadModel
{
    public class Country 
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        public string Id { get; set; }

        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("countryId")]
        public int CountryId { get; set; }

        [BsonElement("postalCode")]
        public string PostalCode { get; set; }
        
        [BsonElement("areaCode")]
        public string AreaCode { get; set; }

    }
}
