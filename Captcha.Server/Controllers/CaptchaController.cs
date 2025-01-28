using Captcha.Application.DTO;
using Captcha.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Captcha.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaptchaController(MousePositionDataService service) : ControllerBase
    {
        private readonly MousePositionDataService _service = service;

        [HttpPost]
        public async Task<IActionResult> AddMousePositionData(MouseMovementData dTO)
        {
            await _service.AddAsync(dTO);
            return Ok();
        }

    }
}
