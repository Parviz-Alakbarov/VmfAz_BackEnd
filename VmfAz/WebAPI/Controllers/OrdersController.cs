using Entities.DTOs.OrderDTOs;
using Microsoft.AspNetCore.Http;
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("add")]
        public async Task<ActionResult> Add(OrderAddDto orderAddDto)
        {
            var result = await _orderService.Add(orderAddDto);
            if (result.Success)
            {
                return StatusCode(201, result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public async Task<ActionResult> Update(OrderUpdateDto orderUpdateDto)
        {
            var result = await _orderService.Update(orderUpdateDto);
            if (result.Success)
            {
                return StatusCode(201, result.Message);
            }
            return BadRequest(result.Message);
        }

    }
}
