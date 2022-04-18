using Business.Abstract;
using Entities.DTOs.OrderDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketItemService _basketItemService;

        public BasketsController(IBasketItemService basketItemService)
        {
            _basketItemService = basketItemService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(BasketItemAddDto basketItemAddDto)
        {
            var result = await _basketItemService.Add(basketItemAddDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAllByUser()
        {
            var result = await _basketItemService.GetAllBasketItemsByUserId();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
