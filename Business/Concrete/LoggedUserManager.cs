using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concreate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class LoggedUserManager : ILoggedUserService
    {
        IUserService _userService;
        IHouseRentalService _houseRentalService;

        public LoggedUserManager(IUserService userService)
        {
            _userService = userService;
        }

        public IResult AddRentalForLoggedUser(User loggedUser, HouseRental rental)
        {
            _houseRentalService.Add(rental);
            return new SuccessResult("Kiralama işlemi başarılı");
        }

        public IDataResult<UserInfoDto> GetProfileInfo(User loggedUser)
        {
            var userinfo = _userService.GetById(loggedUser.Id);
            var userInfoDto = new UserInfoDto { Email = userinfo.Data.Email, FirstName = userinfo.Data.FirstName, LastName = userinfo.Data.LastName };
            return new SuccessDataResult<UserInfoDto>(userInfoDto);
        }

        public IResult Update(User loggedUser, UserInfoDto user)
        {
            loggedUser.FirstName = user.FirstName;
            loggedUser.LastName = user.LastName;
            loggedUser.Email = user.Email;
            var updateResult = _userService.Update(loggedUser);
            if (updateResult.Success)
            {
                return new SuccessResult("Profiliniz Güncellendi");
            }
            return new ErrorResult();
        }
    }
}
