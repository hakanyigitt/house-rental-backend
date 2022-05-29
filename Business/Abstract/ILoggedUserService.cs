using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concreate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ILoggedUserService
    {
        IResult Update(User loggedUser, UserInfoDto user);
        IDataResult<UserInfoDto> GetProfileInfo(User loggedUser);
        IResult AddRentalForLoggedUser(User loggedUser, HouseRental rental);
    }
}
