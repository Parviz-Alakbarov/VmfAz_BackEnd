using Business.Abstract;
using Entities.DTOs.OrderDTOs;
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
        private readonly IProductImageService _productImageService;
        private readonly IBasketItemService _basketItemService;

        public ProductsController(IProductService productService, IProductImageService productImageService, IBasketItemService basketItemService)
        {
            _productService = productService;
            _productImageService = productImageService;
            _basketItemService = basketItemService;
        }

        [HttpPost("addtobasket")]
        public IActionResult AddToBasket(BasketItemAddDto basketItemAddDto)
        {
            var result = _basketItemService.Add(basketItemAddDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        //[HttpPost("")]
        //public IActionResult IcreaseCountOfProduct()
        //{
        //    var result = _basketItemService.IncreaseCount(int );
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result.Message);
        //}


        [HttpPost("addImage")]
        public IActionResult AddImage([FromForm] int productId, [FromForm] IFormFile file)
        {
            var result = _productImageService.Add(productId, file);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
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
                return Ok(result.Message);
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

        [HttpGet("getbybrand")]
        public IActionResult GetByBrand(int brandId)
        {
            var result = _productService.GetProductsByBrandId(brandId);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound(result.Message);
        }


        [HttpGet("getbestseller")]
        public IActionResult GetBestSellers(int count=5)
        {
            var result = _productService.GetBestSellerProducts(count);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound(result.Message);
        }
    }
}
