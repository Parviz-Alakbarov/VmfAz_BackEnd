using Business.Abstract;
using Core.Extensions;
using Core.Utilities.PaginationHelper;
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

        public ProductsController(IProductService productService, IProductImageService productImageService)
        {
            _productService = productService;
            _productImageService = productImageService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromForm]ProductAddDto productAddDto)
        {
            var result = await _productService.Add(productAddDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Remove([FromRoute]int id)
        {
            var result = await _productService.Delete(id);
            if (result.Success)
            {
                return StatusCode(204, result);
            }
            return BadRequest(result);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromForm]ProductUpdateDto productUpdateDto)
        {
            var result = await _productService.Update(id, productUpdateDto);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }


        [HttpGet("getall")]//admin
        public async Task<IActionResult> GetAllDetail()
        {
            var result = await _productService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _productService.GetProductsInGetDto();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _productService.GetProductById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound(result.Message);
        }

        [HttpGet("getProductDetail/{id}")]
        public async Task<IActionResult> GetProductDetail(int id)
        {
            var result = await _productService.GetProductDetils(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound(result.Message);
        }

        [HttpGet("getbybrand/{brandId}")]
        public async Task<IActionResult> GetByBrand(int brandId)
        {
            var result = await _productService.GetProductsByBrandId(brandId);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound(result.Message);
        }

        [HttpGet("getbestseller")]
        public async Task<IActionResult> GetBestSellers(int count = 5)
        {
            var result = await _productService.GetBestSellerProducts(count);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound(result.Message);
        }

        [HttpGet("getbrandbestseller")]
        public async Task<IActionResult> GetBestSellers(int brandId, int count = 5)
        {
            var result = await _productService.GetBestSellerProductsByBrandId(brandId, count);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound(result.Message);
        }

        [HttpGet("getdiscountedproducts")]
        public async Task<IActionResult> GetDiscountedProducts(int? count)
        {
            var result = await _productService.GetDiscountedProducts(count);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound(result.Message);
        }

        [HttpGet("search/{text}")]
        public async Task<IActionResult> SearchProduct(string text)
        {
            var result = await _productService.SearchProducts(text);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound(result.Message);
        }
        [HttpGet("getrelatedproducts/{productId}")]
        public async Task<IActionResult> GetRelatedProducts(int productId)
        {
            var result = await _productService.GetRelatedProducts(productId);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound(result.Message);
        }

        [HttpGet("getpaginatedlist")]
        public async Task<IActionResult> GetPaginatedProducts([FromQuery] UserParams userParams)
        {
            var result = await _productService.GetProductsPagination(userParams);
            if (result.Success)
            {
                Response.AddPaginationHeader(
                    result.Data.CurrentPage, result.Data.TotalItems, result.Data.PageSize, result.Data.TotalPage);

                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getpaginatedlistadmin")]
        public async Task<IActionResult> GetPaginatedProducts([FromQuery] AdminParams adminParams)
        {
            var result = await _productService.GetProductsPaginationAdmin(adminParams);
            if (result.Success)
            {
                Response.AddPaginationHeader(
                    result.Data.CurrentPage, result.Data.TotalItems, result.Data.PageSize, result.Data.TotalPage);

                return Ok(result);
            }
            return BadRequest(result.Message);
        }

    }
}
