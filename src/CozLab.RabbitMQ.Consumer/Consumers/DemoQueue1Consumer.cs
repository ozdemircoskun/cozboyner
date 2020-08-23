using CozLab.Domain.Core.Bus;
using CozLab.Domain.Core.RabbitMQSettings;
using CozLab.Domain.Events;
using CozLab.Domain.MongoEntites;
using CozLab.Domain.MongoInterfaces;
using CozLab.Infra.Data.MongoRepository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;

namespace CozLab.RabbitMQ.Consumer
{
    public class DemoQueue1Consumer : RabbitListener
    {
        private readonly IServiceProvider _services;

        public DemoQueue1Consumer(IServiceProvider services, IOptions<RabbitOptions> options) : base(options)
        {

            _services = services;



            base.RouteKey = "keydemo1";
            base.QueueName = "bydemoqueue1";
            base.ExchangeName = "exchangedemo1";

        }
        public override bool Process(string message)
        {
            try
            {
                using (var scope = _services.CreateScope())
                {

                    var userNoteMongoRepository = scope.ServiceProvider.GetService<IUserNoteMongoRepository>();
                    UserNote userNote = new UserNote();
                    ObjectId id = new ObjectId();
                    userNote.Id = id;
                    userNote.Description = message;
                    userNoteMongoRepository.InsertOneAsync(userNote);

                    var bus = scope.ServiceProvider.GetService<IMediatorHandler>();
                    bus.RaiseEvent(new UserNoteRegisteredEvent(message));
                    return true;
                }
            }
            catch (Exception ex)
            {

                return false;
            }
        }


    }
}