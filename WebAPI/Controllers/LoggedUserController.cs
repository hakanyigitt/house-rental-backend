using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concreate;
using Entities.DTOs;
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
    public class LoggedUserController : ControllerBase
    {
        IUserService _userService;
        ILoggedUserService _loggedUserService;
        IAuthService _authService;

        public LoggedUserController(IUserService userService, ILoggedUserService loggedUserService, IAuthService authService)
        {
            _userService = userService;
            _loggedUserService = loggedUserService;
            _authService = authService;
        }

        [HttpGet("adsoyad")]
        public IActionResult AdSoyad()
        {
            var getLoggedUser = _userService.GetCurrentUser(HttpContext.User.Identity);
            if (getLoggedUser.Success)
            {
                return Ok(new SuccessDataResult<string>(getLoggedUser.Data.FirstName + " " + getLoggedUser.Data.LastName, "Token doğrulandı"));
            }
            else
            {
                return BadRequest(new ErrorDataResult<string>("Giriş yapılmamış"));
            }
        }
        [HttpGet("getprofileinfo")]
        public IActionResult GetProfileInfo()
        {
            var getLoggedUser = _userService.GetCurrentUser(HttpContext.User.Identity);
            if (getLoggedUser.Success)
            {
                var userInfoDto = new UserInfoDto {Id = getLoggedUser.Data.Id ,Email = getLoggedUser.Data.Email, FirstName = getLoggedUser.Data.FirstName, LastName = getLoggedUser.Data.LastName };
                return Ok(new SuccessDataResult<UserInfoDto>(userInfoDto, "Profil bilgileriniz listelendi"));
            }
            else
            {
                return BadRequest(new ErrorDataResult<string>("Giriş yapılmamış"));
            }
        }
        [HttpPost("updateprofile")]
        public IActionResult UpdateProfile(UserInfoDto user)
        {
            var LoggedUser = _userService.GetCurrentUser(HttpContext.User.Identity).Data;
            var result = _loggedUserService.Update(LoggedUser, user);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("renewtoken")]
        public IActionResult RenewToken()
        {
            var LoggedUser = _userService.GetCurrentUser(HttpContext.User.Identity).Data;
            var result = _authService.CreateAccessToken(LoggedUser);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("rent")]
        public IActionResult RentHouse(HouseRental rentalDto)
        {
            var LoggedUser = _userService.GetCurrentUser(HttpContext.User.Identity).Data;
            var getUser = _userService.GetById(rentalDto.UserId).Data;
            HouseRental rental = new HouseRental { HouseId = rentalDto.HouseId, UserId = rentalDto.UserId, DayToStay = rentalDto.UserId, TotalPrice = rentalDto.TotalPrice, RentalDate = rentalDto.RentalDate, EndDate= rentalDto.EndDate };
            var result = _loggedUserService.AddRentalForLoggedUser(LoggedUser, rental);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

    }
}
