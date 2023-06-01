using Microsoft.AspNetCore.Mvc;
using SamianSoft.Application.Services.ObjectTemplate;
using SamianSoft.Application.Services.ObjectTemplate.Commands;

namespace AmirTahanTemplateSamianSoft.Controllers
{
    [Route("[controller]")]
    public class ObjectTemplateController : BasicController
    {
        private readonly IAddObjectTemplateRepository _addObjectTemplate;
        public ObjectTemplateController(IAddObjectTemplateRepository addObjectTemplate)
        {
            _addObjectTemplate = addObjectTemplate;
        }

        [HttpPost("Save")]
        public async Task<IActionResult> Save(ObjectTemplateDto objectTemplate)
        {
            if (objectTemplate == null)
                return BadRequest("Object required.");

            return ReturnJsonResult(await _addObjectTemplate.Execute(objectTemplate));
        }
    }
}
