using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace CozLab.Domain.Core.MongoEntites
{
    public interface IDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        ObjectId Id { get; set; }
         
    }


}
