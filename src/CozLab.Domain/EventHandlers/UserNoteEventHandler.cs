using CozLab.Domain.Events;
using CozLab.Domain.RabbitMQInterfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CozLab.Domain.EventHandlers
{
    public class UserNoteEventHandler :
        INotificationHandler<UserNoteRegisteredEvent>
    {
        
        public Task Handle(UserNoteRegisteredEvent message, CancellationToken cancellationToken)
        { 
            return Task.CompletedTask;
        }
    }
}