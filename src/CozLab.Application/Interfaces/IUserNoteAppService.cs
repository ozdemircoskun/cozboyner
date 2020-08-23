using CozLab.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace CozLab.Application.Interfaces
{
    public interface IUserNoteAppService : IDisposable
    {
        void Register(UserNoteViewModel userNoteViewModel);
        IEnumerable<UserNoteViewModel> GetAll();  
    }
}
