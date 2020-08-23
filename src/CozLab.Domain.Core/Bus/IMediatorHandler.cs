using CozLab.Domain.Core.Commands;
using CozLab.Domain.Core.Events;
using System.Threading.Tasks;


namespace CozLab.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
