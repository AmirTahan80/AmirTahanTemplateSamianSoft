using Microsoft.AspNetCore.Mvc;
using SamianSoft.Application.Services.ObjectTemplate;
using SamianSoft.Application.Services.ObjectTemplate.Commands;
using SamianSoft.Infrastructure.Elasticsearch;

namespace AmirTahanTemplateSamianSoft.Controllers
{
    [Route("[controller]")]
    public class ObjectTemplateController : BasicController
    {
        private readonly IAddObjectTemplateRepository _addObjectTemplate;
        private readonly IElasticsearchSetup _elasticsearchSetup;
        public ObjectTemplateController(IAddObjectTemplateRepository addObjectTemplate, IElasticsearchSetup elasticsearchSetup)
        {
            _addObjectTemplate = addObjectTemplate;
            _elasticsearchSetup = elasticsearchSetup;
        }

        [HttpPost("Save")]
        public async Task<IActionResult> Save(ObjectTemplateDto objectTemplate)
        {
            var res = await _addObjectTemplate.Execute(objectTemplate);
            if (res.IsSuccess)
            {
                var result = await _elasticsearchSetup.IndexObject(objectTemplate);
                if (result.IsSuccess)
                    return Ok("Its work");
            }
            return BadRequest();
        }
    }
}
