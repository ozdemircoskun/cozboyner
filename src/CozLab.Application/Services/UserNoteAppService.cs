using AutoMapper;
using AutoMapper.QueryableExtensions;
using CozLab.Application.Interfaces;
using CozLab.Application.ViewModels;
using CozLab.Domain.Commands;
using CozLab.Domain.Core.Bus;
using CozLab.Domain.MongoInterfaces;
using System;
using System.Collections.Generic;

namespace CozLab.Application.Services
{
    public class UserNoteAppService : IUserNoteAppService
    {
        private readonly IMapper _mapper;
        private readonly IUserNoteMongoRepository _userNoteMongoRepository;
        private readonly IMediatorHandler Bus;

        public UserNoteAppService(IMapper mapper,
                                  IUserNoteMongoRepository userNoteMongoRepository,
                                  IMediatorHandler bus)
        {
            Bus = bus;
            _mapper = mapper;
            _userNoteMongoRepository = userNoteMongoRepository;
        }

        public IEnumerable<UserNoteViewModel> GetAll()
        {
            return _userNoteMongoRepository.AsQueryable().ProjectTo<UserNoteViewModel>(_mapper.ConfigurationProvider);
        }

        public void Register(UserNoteViewModel userNoteViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewUserNoteCommand>(userNoteViewModel);
            Bus.SendCommand(registerCommand);
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
