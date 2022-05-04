using Core.Utilities.Results;
using Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IHouseRentalService
    {
        IResult Add(HouseRental houseRental);
        IResult Update(HouseRental houseRental);
        IResult Delete(HouseRental houseRental);
        IDataResult<List<HouseRental>> GetAll();
        IDataResult<HouseRental> GetById(int id);
    }
}
