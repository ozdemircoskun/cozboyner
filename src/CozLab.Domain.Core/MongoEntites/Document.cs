using MongoDB.Bson;
using System;

namespace CozLab.Domain.Core.MongoEntites
{
    public abstract class Document : IDocument
    {
        public ObjectId Id { get; set; }
         
    }
}
