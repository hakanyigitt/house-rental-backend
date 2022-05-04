using Business.Abstract;
using Entities.Concreate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HouseImagesController : Controller
    {
        IHouseImageService _houseImageService;

        public HouseImagesController(IHouseImageService houseImageService)
        {
            _houseImageService = houseImageService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _houseImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _houseImageService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyhouseid")]
        public IActionResult GetByHouseId(int id)
        {
            var result = _houseImageService.GetByHouseId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] IFormFile file, [FromForm] HouseImage houseImage)
        {
            var result = _houseImageService.Add(file, houseImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm] IFormFile file, [FromForm] int id)
        {
            var houseImage = _houseImageService.GetById(id).Data;
            var result = _houseImageService.Update(file, houseImage);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(HouseImage houseImage)
        {
            var image = _houseImageService.GetById(houseImage.Id).Data;
            var result = _houseImageService.Delete(image);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
