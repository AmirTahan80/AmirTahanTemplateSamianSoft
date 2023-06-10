using AutoMapper;
using Microsoft.Extensions.Caching.Distributed;
using SamianSoft.Application.DTOs;
using SamianSoft.Domain.DataInterface;
using System.Net;
using System.Text.Json;
using System.Text;

namespace SamianSoft.Application.Services.ObjectTemplate.Commands
{
    public class AddObjectTemplateRepository : IAddObjectTemplateRepository
    {
        #region Constructor and properties
        private readonly IMapper _mapper;
        private readonly ISF_DbContext _sf_DbContext;
        private readonly IDistributedCache _cache;
        public AddObjectTemplateRepository(ISF_DbContext sf_DbContext,
            IMapper mapper, IDistributedCache cache)
        {
            _sf_DbContext = sf_DbContext;
            _mapper = mapper;
            _cache = cache;
        }
        #endregion

        #region Methods
        public async Task<ResultDto> Execute(ObjectTemplateDto objectTemplateDto)
        {
            try
            { 
                var createObject = _mapper.Map<Domain.Entity.ObjectTemplate>(objectTemplateDto);
                //var objectCreated = await _sf_DbContext.ObjectTemplates.AddAsync(createObject);
                //_sf_DbContext.SaveChangesAsync();
                string cachedDataString = JsonSerializer.Serialize(createObject);
                var dataToCache = Encoding.UTF8.GetBytes(cachedDataString);

                // Setting up the cache options
                DistributedCacheEntryOptions options = new DistributedCacheEntryOptions()
                    .SetAbsoluteExpiration(DateTime.Now.AddMinutes(5))
                    .SetSlidingExpiration(TimeSpan.FromMinutes(3));
                _cache.SetAsync(createObject.CreateUserId.ToString()
                    , dataToCache
                    , options:options);
                return new()
                {
                    Data = createObject,
                    IsSuccess = true,
                    Message = "Success To create a object",
                    StatusCode = HttpStatusCode.OK
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
