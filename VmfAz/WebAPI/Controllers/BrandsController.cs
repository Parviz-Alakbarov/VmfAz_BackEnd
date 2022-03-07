using Business.Abstract;
using Entities.DTOs.BrandDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        public IActionResult Add([FromForm] BrandPostDto dto)
        {
        /*    BrandPostDto dto = new BrandPostDto()
            {
                Name = name,
                Description = description,
                Image = image,
                PosterImage = posterImage
            };*/
            var result = _brandService.Add(dto);
            if (result.Success)
            {
                return StatusCode(201, result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _brandService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPut("update")]
        public ActionResult Update([FromForm] int id,[FromForm] BrandPostDto dto)
        {
            //BrandPostDto dto = new BrandPostDto()
            //{
            //    Name = name,
            //    Description = description,
            //    Image = image,
            //    PosterImage = posterImage
            //};
            var result = _brandService.Update(id, dto);
            if (result.Success) 
            {
                return StatusCode(201, result.Message);
            }
            return BadRequest(result.Message);
        }
    }
}
