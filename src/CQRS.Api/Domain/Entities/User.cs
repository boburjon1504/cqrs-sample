using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CQRS.Api.Domain.Entities;

public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.Binary)]
    [BsonGuidRepresentation(GuidRepresentation.Standard)]
    public Guid Id { get; set; }

    public string FirstName { get; set; } = default!;

    public string LastName { get; set; } = default!;
}
