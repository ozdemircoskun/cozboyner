using CozLab.Domain.Commands;
using CozLab.Domain.Core.Bus;
using CozLab.Domain.Core.Notifications;
using CozLab.Domain.Events;
using CozLab.Domain.MongoEntites;
using CozLab.Domain.MongoInterfaces;
using CozLab.Domain.RabbitMQInterfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CozLab.Domain.CommandHandlers
{
    public class UserNoteCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewUserNoteCommand, bool>
    {
        private readonly IRabbitManager _IRabbitManager;
        private readonly IMediatorHandler Bus;

        public UserNoteCommandHandler(IRabbitManager rabbitManager,
                                      IMediatorHandler bus,
                                      INotificationHandler<DomainNotification> notifications) : base(bus, notifications)
        {
            _IRabbitManager = rabbitManager;
            Bus = bus;
        }

        public Task<bool> Handle(RegisterNewUserNoteCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }


            _IRabbitManager.Publish(new
            {
                demotext = message.Description
            },
                                 "exchangedemo1",
                                 "topic",
                                 "keydemo1"
                           );
               
            return Task.FromResult(true);
        }
    }
}