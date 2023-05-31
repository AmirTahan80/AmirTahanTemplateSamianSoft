using AutoMapper;

namespace SamianSoft.Application.Services.ObjectTemplate
{
    //This is class is using for impeliment the automapper...
    public class ObjectTemplateProfile : Profile
    {
        public ObjectTemplateProfile()
        {
            CreateMap<ObjectTemplateDto,Domain.Entity.ObjectTemplate>();
            //CreateMap<Domain.Entity.ObjectTemplate,ObjectTemplateDto>();
        }
    }
}
