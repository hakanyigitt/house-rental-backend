using Core.Utilities.Results;
using Entities.Concreate;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IHouseImageService
    {
        IDataResult<List<HouseImage>> GetAll();
        IDataResult<HouseImage> GetById(int id);
        IDataResult<List<HouseImage>> GetByHouseId(int houseId);
        IResult Add(IFormFile file, HouseImage houseImage);
        IResult Delete(HouseImage houseImage);
        IResult Update(IFormFile file, HouseImage houseImage);
    }
}
