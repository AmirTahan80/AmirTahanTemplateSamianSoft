using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SamianSoft.Application.Services.ObjectTemplate;
using SamianSoft.Application.Services.ObjectTemplate.Commands;
using SamianSoft.Infrastructure.Elasticsearch;

namespace AmirTahanTemplateSamianSoft.Controllers
{
    [Route("[controller]")]
    public class ObjectTemplateController : BasicController
    {
        private readonly IAddObjectTemplateRepository _addObjectTemplate;
        private readonly ISerilogLogginSettup _serilogLogginSettup;
        private readonly IElasticsearchSetup _elasticsearchSetup;
        public ObjectTemplateController(IAddObjectTemplateRepository addObjectTemplate,
            ISerilogLogginSettup serilogLogginSettup, IElasticsearchSetup elasticsearchSetup)
        {
            _addObjectTemplate = addObjectTemplate;
            _serilogLogginSettup = serilogLogginSettup;
            _elasticsearchSetup = elasticsearchSetup;
        }

        [HttpPost("Save")]
        public async Task<IActionResult> Save(ObjectTemplateDto objectTemplate)
        {
            if (objectTemplate is null)
                return BadRequest("Object required.");
            var res = await _addObjectTemplate.Execute(objectTemplate);
            if(res.IsSuccess)
            {
                var objectTemplateJson = JsonConvert.SerializeObject(objectTemplate);
                //var result = _serilogLogginSettup.SaveToElastic(objectTemplateJson);
                var result = _elasticsearchSetup.IndexObject(objectTemplateJson);
                //if(result.IsSuccess)
                return Ok("Its work");
            }
            return BadRequest();
        }
    }
}
