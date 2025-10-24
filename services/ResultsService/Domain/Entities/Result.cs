using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ResultsService.Domain.Entities;

public class Result
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public Guid Id { get; set; }

    [BsonElement("complaints")]
    public string Complaints { get; set; } = null!;

    [BsonElement("conclusion")]
    public string Conclusion { get; set; } = null!;

    [BsonElement("recommendations")]
    public string Recommendations { get; set; } = null!;

    [BsonElement("appointment_id")]
    [BsonRepresentation(BsonType.String)]
    public Guid AppointmentId { get; set; }
}
