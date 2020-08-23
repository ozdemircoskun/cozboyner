using CozLab.Application.Interfaces;
using CozLab.Application.Services;
using CozLab.Domain.CommandHandlers;
using CozLab.Domain.Commands;
using CozLab.Domain.Core.Bus;
using CozLab.Domain.Core.Notifications;
using CozLab.Domain.EventHandlers;
using CozLab.Domain.Events;
using CozLab.Domain.MongoInterfaces;
using CozLab.Infra.CrossCutting.Bus;
using CozLab.Infra.Data.MongoRepository;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CozLab.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // ASP.NET Authorization Polices

            // Application
            services.AddScoped<IUserNoteAppService, UserNoteAppService>();
             

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<UserNoteRegisteredEvent>, UserNoteEventHandler>();


            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterNewUserNoteCommand, bool>, UserNoteCommandHandler>();

            // MongoDB
            services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));
            services.AddTransient<IUserNoteMongoRepository, UserNoteMongoRepository>();
             

        }
    }
}