using CozLab.Domain.Core.MongoEntites;

namespace CozLab.Domain.MongoEntites
{
    [BsonCollection("T_DOC_UserNote")]
    public class UserNote : BaseEntity
    {
        public string Description { get; set; }

        
    }
}
