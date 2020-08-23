using CozLab.Domain.Core.Commands;
using MongoDB.Bson;

namespace CozLab.Domain.Commands
{
    public abstract class UserNoteCommand : Command
    {
        public ObjectId Id { get; protected set; }

        public string Description { get; protected set; }


    }
}