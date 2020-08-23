using AutoMapper;
using CozLab.Application.ViewModels;
using CozLab.Domain.MongoEntites;

namespace CozLab.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<UserNote, UserNoteViewModel>();
        }
    }
}
