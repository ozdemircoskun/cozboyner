using CozLab.Domain.Core.Bus;
using CozLab.Domain.Core.Commands;
using CozLab.Domain.Core.Events;
using MediatR;
using System.Threading.Tasks;

namespace CozLab.Infra.CrossCutting.Bus
{
    public sealed class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator _mediator; 

        public InMemoryBus( IMediator mediator)
        { 
            _mediator = mediator;
        }

        public Task SendCommand<T>(T command) where T : Command
        {
            return _mediator.Send(command);
        }

        public Task RaiseEvent<T>(T @event) where T : Event
        {
             
            return _mediator.Publish(@event);
        }
    }
}