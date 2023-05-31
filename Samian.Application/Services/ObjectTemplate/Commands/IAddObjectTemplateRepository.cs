using SamianSoft.Application.DTOs;

namespace SamianSoft.Application.Services.ObjectTemplate.Commands
{
    public interface IAddObjectTemplateRepository
    {
        Task<ResultDto> Execute(ObjectTemplateDto objectTemplateDto);
    }
}
