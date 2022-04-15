using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopsController : ControllerBase
    {
        private readonly IShopService _shopService;

        public ShopsController(IShopService shopService)
        {
            _shopService = shopService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _shopService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getshopbyproduct/{id}")]
        public async Task<IActionResult> GetShopsByProduct(int id)
        {
            var result = await _shopService.GetShopsByProduct(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }


        [HttpPost("add")]
        public async Task<IActionResult> Add(ShopPostDto shopDto)
        {
            var result = await _shopService.Add(shopDto);
            if (result.Success)
            {
                return StatusCode(201, result.Message);
            }
            return BadRequest(result.Message);
        }


        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var result = await _shopService.Delete(id);
            if (result.Success)
            {
                return StatusCode(204, result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, ShopPostDto shopPostDto)
        {
            var result = await _shopService.Delete(id);
            if (result.Success)
            {
                return StatusCode(204, result.Message);
            }
            return BadRequest(result.Message);
        }
    }
}
