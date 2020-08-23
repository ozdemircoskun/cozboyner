using CozLab.Domain.Core.Events;

namespace CozLab.Domain.Events
{
    public class UserNoteRegisteredEvent : Event
    {
        public UserNoteRegisteredEvent(string description)
        {

            Description = description;
        }

        public string Description { get; private set; }


    }
}