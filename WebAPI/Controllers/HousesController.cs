using Business.Abstract;
using Entities.Concreate;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HousesController : ControllerBase
    {
        IHouseService _houseService;

        public HousesController(IHouseService houseService)
        {
            _houseService = houseService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _houseService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _houseService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }      

        [HttpGet("getbycategoryid")]
        public IActionResult GetByCategoryId(int categoryId)
        {
            var result = _houseService.GetByCategoryId(categoryId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbycityid")]
        public IActionResult GetByCityId(int cityId)
        {
            var result = _houseService.GetByCityId(cityId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("gethousedetails")]
        public IActionResult GetCarDetails()
        {
            var result = _houseService.GetHouseDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("gethousedetailsbyhouseid")]
        public IActionResult GetHouseDetailsByHouseId(int houseId)
        {
            var result = _houseService.GetHouseDetailsByHouseId(houseId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("gethousedetailsbyfilter")]
        public IActionResult GetHouseDetailsByFilter(int categoryId, int cityId)
        {
            var result = _houseService.GetHouseDetailsByFilter(categoryId, cityId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("gethousebycategorydetaildtos")]
        public IActionResult GetHouseByCategoryIdDetailDtos(int categoryId)
        {
            var result = _houseService.GetHouseByCategoryIdDetailDtos(categoryId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("gethousebycityiddetaildtos")]
        public IActionResult GetCarByColorIdDetailDtos(int cityId)
        {
            var result = _houseService.GetHouseByCityIdDetailDtos(cityId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(House house)
        {
            house.Date = DateTime.Now;
            var result = _houseService.Add(house);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(House house)
        {
            var result = _houseService.Update(house);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(House house)
        {
            var result = _houseService.Delete(house);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
