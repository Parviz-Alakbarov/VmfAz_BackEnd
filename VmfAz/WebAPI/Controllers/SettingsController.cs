using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
        public async Task<IActionResult> GetAll()
        {
            var result = await _settingService.GetAll();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbykey")]
        public async Task<IActionResult> GetByKey(string key)
        {
            var result = await _settingService.GetByKey(key);
            if (result != null)
            {
                return StatusCode(200,result);
            }
            return BadRequest(result.Message);
        }


        [HttpPut("update")]
        public async Task<IActionResult> Update([FromForm] SettingPostDto settingPostDto)
        {
            var result = await _settingService.Update(settingPostDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }


        [HttpGet("getCountries")]
        public async Task<IActionResult> GetCountries()
        {
            var result = await _settingService.GetCountries();
            if (result != null)
            {
                return StatusCode(200, result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getCitiesByCountry/{countryId}")]
        public async Task<IActionResult> GetCitiesByCountry(int countryId)
        {
            var result = await _settingService.GetCitiesByCountry(countryId);
            if (result != null)
            {
                return StatusCode(200, result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getproductfunctionality")]
        public async Task<IActionResult> GetProductFuntionalities()
        {
            var result = await _settingService.GetProductFuntionalities();
            if (result != null)
            {
                return StatusCode(200, result);
            }
            return BadRequest(result.Message);
        }
    }
}
