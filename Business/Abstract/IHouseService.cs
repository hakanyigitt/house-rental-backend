using Core.Utilities.Results;
using Entities.Concreate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IHouseService
    {
        IResult Add(House house);
        IResult Update(House house);
        IResult Delete(House house);
        IDataResult<List<House>> GetAll();
        IDataResult<House> GetById(int id);
        IDataResult<List<House>> GetByCategoryId(int categoryId);
        IDataResult<List<House>> GetByCityId(int cityId);
        IDataResult<List<HouseDetailDto>> GetHouseDetails();
        IDataResult<List<HouseDetailDto>> GetHouseDetailsByHouseId(int houseId);
        IDataResult<List<HouseDetailDto>> GetHouseDetailsByFilter(int categoryId, int cityId);
        IDataResult<List<HouseDetailDto>> GetHouseByCategoryIdDetailDtos(int categoryId);
        IDataResult<List<HouseDetailDto>> GetHouseByCityIdDetailDtos(int cityId);
    }
}
