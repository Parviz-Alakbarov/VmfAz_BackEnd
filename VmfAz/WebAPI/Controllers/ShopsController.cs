using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetAll()
        {
            var result = _shopService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getshopbyproduct/{id}")]
        public IActionResult GetShopsByProduct(int id)
        {
            var result = _shopService.GetShopsByProduct(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }


        [HttpPost("add")]
        public IActionResult Add(Shop shop)
        {
            var result = _shopService.Add(shop);
            if (result.Success)
            {
                return StatusCode(201, result.Message);
            }
            return BadRequest(result.Message);
        }


        [HttpDelete("delete")]
        public IActionResult Remove(int id)
        {
            var result = _shopService.Delete(id);
            if (result.Success)
            {
                return StatusCode(204, result.Message);
            }
            return BadRequest(result.Message);
        }
    }
}
