using Microsoft.AspNetCore.Mvc;
using SamianSoft.Application.DTOs;
using System.Net;

namespace AmirTahanTemplateSamianSoft.Controllers
{
    /// <summary>
    /// This controller just for settin up the base attributes and inheritance, Other controller should inheritance this.
    /// </summary>
    [ApiController]
    public abstract class BasicController : ControllerBase
    {

        protected IActionResult ReturnJsonResult(ResultDto resultDto)
        {
            if(resultDto.IsSuccess)
                return Ok(resultDto);
            else
            {
                switch(resultDto.StatusCode)
                {
                    case HttpStatusCode.BadRequest:
                        return BadRequest(resultDto);
                    default:
                        return Problem(resultDto.Message, resultDto.Data.ToString(), (int)resultDto.StatusCode, "Error");
                }
            }
        }

    }
}
