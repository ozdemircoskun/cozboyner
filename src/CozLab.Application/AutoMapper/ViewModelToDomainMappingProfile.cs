using AutoMapper;
using CozLab.Application.ViewModels;
using CozLab.Domain.Commands;

namespace CozLab.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<UserNoteViewModel, RegisterNewUserNoteCommand>()
                .ConstructUsing(c => new RegisterNewUserNoteCommand(c.Description));

        }
    }
}
