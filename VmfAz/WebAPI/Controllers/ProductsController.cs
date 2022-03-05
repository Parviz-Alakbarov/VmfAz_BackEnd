using Business.Abstract;
using Entities.DTOs.ProductDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("add")]
        public IActionResult Add(ProductAddDto productAddDto)
        {
            var result = _productService.Add(productAddDto);
            if (result.Success)
            {
                return StatusCode(201, result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpDelete("delete")]
        public IActionResult Remove(int id)
        {
            var result = _productService.Delete(id);
            if (result.Success)
            {
                return StatusCode(204, result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPut("update")]
        public IActionResult Update(int id, ProductUpdateDto productUpdateDto)
        {
            var result = _productService.Update(id,productUpdateDto);
            if (result.Success)
            {
                return StatusCode(204, result.Message);
            }
            return BadRequest(result.Message);
        }


        [HttpGet("")]
        public IActionResult GetAll()
        {
            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetProductById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound(result.Message);
        }

        [HttpGet("getProductDetail")]
        public IActionResult GetProductDetail(int id)
        {
            var result = _productService.GetProductDetils(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound(result.Message);
        }
    }
}
