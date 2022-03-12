using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        private readonly ISettingService _settingService;

        public SettingsController(ISettingService settingService)
        {
            _settingService = settingService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _settingService.GetAll();
            if (result!=null)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
