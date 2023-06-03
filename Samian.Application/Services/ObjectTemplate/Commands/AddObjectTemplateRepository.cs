using AutoMapper;
using SamianSoft.Application.DTOs;
using SamianSoft.Domain.DataInterface;
using System.Net;

namespace SamianSoft.Application.Services.ObjectTemplate.Commands
{
    public class AddObjectTemplateRepository : IAddObjectTemplateRepository
    {
        #region Constructor and properties
        private readonly IMapper _mapper;
        private readonly ISF_DbContext _sf_DbContext;
        public AddObjectTemplateRepository(ISF_DbContext sf_DbContext,
            IMapper mapper)
        {
            _sf_DbContext = sf_DbContext;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        public async Task<ResultDto> Execute(ObjectTemplateDto objectTemplateDto)
        {
            try
            { 
                var createObject = _mapper.Map<Domain.Entity.ObjectTemplate>(objectTemplateDto);
                var objectCreated = await _sf_DbContext.ObjectTemplates.AddAsync(createObject);
                var res = await _sf_DbContext.SaveChangesAsync();
                if (res > 0)
                    return new()
                    {
                        Data = createObject,
                        IsSuccess = true,
                        Message = "Success To create a object",
                        StatusCode = HttpStatusCode.OK
                    };
                else
                    return new()
                    {
                        Data = createObject,
                        Message = "Faield to save the object template",
                        StatusCode = HttpStatusCode.BadRequest,
                        IsSuccess = false
                    };
            }
            catch (Exception ex)
            {

                return new()
                {
                    Data = ex,
                    Message = ex.Message,
                    StatusCode = HttpStatusCode.InternalServerError,
                    IsSuccess=false
                };
            }
        }
        #endregion
    }
}
