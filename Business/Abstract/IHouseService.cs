using Core.Utilities.Results;
using Entities.Concreate;
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
    }
}
