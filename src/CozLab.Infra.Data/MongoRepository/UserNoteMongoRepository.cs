using CozLab.Domain.Core.MongoSettings;
using CozLab.Domain.MongoEntites;
using CozLab.Domain.MongoInterfaces;

namespace CozLab.Infra.Data.MongoRepository
{

    public class UserNoteMongoRepository : MongoRepository<UserNote>, IUserNoteMongoRepository
    {
        public UserNoteMongoRepository(IMongoDbSettings settings)
            : base(settings)
        {

        }
    }

}
