using Business.Abstract;
using Entities.DTOs;
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
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbykey")]
        public IActionResult GetByKey(string key)
        {
            var result = _settingService.GetByKey(key);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }


        [HttpPut("update")]
        public IActionResult Update([FromForm] SettingPostDto settingPostDto)
        {
            var result = _settingService.Update(settingPostDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

    }
}
