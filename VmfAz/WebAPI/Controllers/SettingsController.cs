using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete.ProductEntries;
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

        [HttpGet("getproductwaterresistances")]
        public async Task<IActionResult> GetProductWaterResistances()
        {
            var result = await _settingService.GetProductWaterResistances();
            if (result != null)
            {
                return StatusCode(200, result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getproductstyles")]
        public async Task<IActionResult> GetProductStyles()
        {
            var result = await _settingService.GetProductStyles();
            if (result != null)
            {
                return StatusCode(200, result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getproductmechanisms")]
        public async Task<IActionResult> GetProductMechanisms()
        {
            var result = await _settingService.GetProductMechanisms();
            if (result != null)
            {
                return StatusCode(200, result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getproductbelttypes")]
        public async Task<IActionResult> GetProductBeltTypes()
        {
            var result = await _settingService.GetProductBeltTypes();
            if (result != null)
            {
                return StatusCode(200, result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getproductcasematerials")]
        public async Task<IActionResult> GetProductCaseMaterials()
        {
            var result = await _settingService.GetProductCaseMaterials();
            if (result != null)
            {
                return StatusCode(200, result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getproductcaseshapes")]
        public async Task<IActionResult> GetProductCaseShapes()
        {
            var result = await _settingService.GetProductCaseShapes();
            if (result != null)
            {
                return StatusCode(200, result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getproductcasesizes")]
        public async Task<IActionResult> GetProductCaseSizes()
        {
            var result = await _settingService.GetProductCaseSizes();
            if (result != null)
            {
                return StatusCode(200, result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getproductglasstypes")]
        public async Task<IActionResult> GetProductGlassTypes()
        {
            var result = await _settingService.GetProductGlassTypes();
            if (result != null)
            {
                return StatusCode(200, result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getgenders")]
        public async Task<IActionResult> GetGenders()
        {
            var result = await _settingService.GetGenders();
            if (result != null)
            {
                return StatusCode(200, result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getcolors.{format}"), FormatFilter]
        public async Task<IActionResult> GetColors()
        {
            //var result = await _settingService.GetColors();
            //if (result != null)
            //{
            //    return StatusCode(200, new SuccessDataResult<Color>(new Color { HexValue="2323",Id=1,Name="sari"}));
            //}
            //return BadRequest(result.Message);



            var result = await _settingService.GetColors();
            if (result != null)
            {
                return StatusCode(200, result);
            }
            return BadRequest(result.Message);

        }
    }
}
