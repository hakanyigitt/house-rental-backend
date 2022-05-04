using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concreate
{
    public class HouseManager : IHouseService
    {
        IHouseDal _houseDal;
        public HouseManager(IHouseDal houseDal)
        {
            _houseDal = houseDal;
        }

        public IResult Add(House house)
        {
            _houseDal.Add(house);
            return new SuccessResult(Messages.HouseAdded);
        }

        public IResult Delete(House house)
        {
            _houseDal.Delete(house);
            return new SuccessResult(Messages.HouseDeleted);
        }

        public IDataResult<List<House>> GetAll()
        {
            return new SuccessDataResult<List<House>>(_houseDal.GetAll(), Messages.HouseListed);
        }

        public IDataResult<House> GetById(int id)
        {
            return new SuccessDataResult<House>(_houseDal.Get(h => h.Id == id));
        }

        public IResult Update(House house)
        {
            _houseDal.Update(house);
            return new SuccessResult(Messages.HouseUpdated);
        }
    }
}
