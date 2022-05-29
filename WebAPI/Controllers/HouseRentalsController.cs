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
    public class HouseRentalsController : ControllerBase
    {
        IHouseRentalService _houseRentalService;
        public HouseRentalsController(IHouseRentalService houseRentalService)
        {
            _houseRentalService = houseRentalService;
        }
        
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _houseRentalService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getallbyid")]
        public IActionResult GetAllById(int id)
        {
            var result = _houseRentalService.GetAllById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _houseRentalService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(HouseRental houseRental)
        {
            var result = _houseRentalService.Add(houseRental);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(HouseRental houseRental)
        {
            var result = _houseRentalService.Update(houseRental);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(HouseRental houseRental)
        {
            var result = _houseRentalService.Delete(houseRental);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getrentaldetails")]
        public IActionResult GetRentalDetails()
        {
            var result = _houseRentalService.GetRentalDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("checkifcanhouseberentedbetweenselecteddates")]
        public IActionResult CheckIfCanHouseBeRentedBetweenSelectedDates(int houseId, DateTime rentDate, DateTime returnDate)
        {
            var result = _houseRentalService.CheckIfCanHouseBeRentedBetweenSelectedDates(houseId, rentDate, returnDate);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
