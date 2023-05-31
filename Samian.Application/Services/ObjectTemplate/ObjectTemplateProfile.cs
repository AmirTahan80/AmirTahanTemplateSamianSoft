using AutoMapper;

namespace SamianSoft.Application.Services.ObjectTemplate
{
    //This is class is using for impeliment the automapper...
    internal class ObjectTemplateProfile : Profile
    {
        public ObjectTemplateProfile()
        {
            CreateMap<Domain.Entity.ObjectTemplate, ObjectTemplateDto>();
        }
    }
}
