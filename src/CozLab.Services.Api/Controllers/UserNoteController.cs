using CozLab.Application.Interfaces;
using CozLab.Application.ViewModels;
using CozLab.Domain.Core.Bus;
using CozLab.Domain.Core.Notifications;
using CozLab.Domain.MongoInterfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CozLab.Services.Api.Controllers
{
 
    public class UserNoteController : ApiController
    {
        private readonly IUserNoteAppService _userNoteAppService; 
        public UserNoteController(
            IUserNoteAppService userNoteAppService,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _userNoteAppService = userNoteAppService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("usernote-getall")]
        public IActionResult Get()
        {

            return Response(_userNoteAppService.GetAll());
        }
        [HttpPost] 
        [Route("usernote-insert")]
        public IActionResult Post([FromBody] UserNoteViewModel userNoteViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(userNoteViewModel);
            }

            _userNoteAppService.Register(userNoteViewModel);

            return Response(userNoteViewModel);
        }


    }
}
