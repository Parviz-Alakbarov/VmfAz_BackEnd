using Business.Abstract;
using Entities.DTOs.BrandDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromForm] BrandPostDto dto)
        {
            var result = await _brandService.Add(dto);
            if (result.Success)
            {
                return StatusCode(201, result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _brandService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }


        [HttpGet("getbrandsonlywithname")]
        public async Task<IActionResult> GetBrandsOnlyWithName()
        {
            var result = await _brandService.GetBrandsOnlyWithName();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbrandswithimage")]
        public async Task<IActionResult> GetBrandsWithImage()
        {
            var result = await _brandService.GetBrandsWithImage();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbrandDetail/{id}")]
        public async Task<IActionResult> GetBrandDetail(int id)
        {
            var result = await _brandService.GetBrandDetail(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }




        [HttpPut("update")]
        public async Task<IActionResult> Update([FromForm] int id,[FromForm] BrandPostDto dto)
        {
            var result = await _brandService.Update(id, dto);
            if (result.Success) 
            {
                return StatusCode(201, result.Message);
            }
            return BadRequest(result.Message);
        }
    }
}
