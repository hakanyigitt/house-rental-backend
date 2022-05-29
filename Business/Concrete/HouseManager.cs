using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concreate;
using Entities.DTOs;
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

        public IDataResult<List<House>> GetByCategoryId(int categoryId)
        {
            return new SuccessDataResult<List<House>>(_houseDal.GetAll(c => c.CategoryId == categoryId), Messages.HouseListed);
        }

        public IDataResult<List<House>> GetByCityId(int cityId)
        {
            return new SuccessDataResult<List<House>>(_houseDal.GetAll(c => c.CityId == cityId), Messages.HouseListed);
        }

        public IDataResult<House> GetById(int id)
        {
            return new SuccessDataResult<House>(_houseDal.Get(h => h.Id == id));
        }

        public IDataResult<List<HouseDetailDto>> GetHouseByCategoryIdDetailDtos(int categoryId)
        {
            return new SuccessDataResult<List<HouseDetailDto>>(_houseDal.GetHouseDetails(c => c.CategoryId == categoryId), Messages.HouseDetailListed);
        }

        public IDataResult<List<HouseDetailDto>> GetHouseByCityIdDetailDtos(int cityId)
        {
            return new SuccessDataResult<List<HouseDetailDto>>(_houseDal.GetHouseDetails(c => c.CityId == cityId), Messages.HouseDetailListed);
        }

        public IDataResult<List<HouseDetailDto>> GetHouseDetails()
        {
            return new SuccessDataResult<List<HouseDetailDto>>(_houseDal.GetHouseDetails(), Messages.HouseDetailListed);
        }

        public IDataResult<List<HouseDetailDto>> GetHouseDetailsByFilter(int categoryId, int cityId)
        {
            return new SuccessDataResult<List<HouseDetailDto>>(_houseDal.GetHouseDetails(c => c.CategoryId == categoryId && c.CityId == cityId));
        }

        public IDataResult<List<HouseDetailDto>> GetHouseDetailsByHouseId(int houseId)
        {
            return new SuccessDataResult<List<HouseDetailDto>>(_houseDal.GetHouseDetails(h => h.HouseId == houseId));
        }

        public IResult Update(House house)
        {
            _houseDal.Update(house);
            return new SuccessResult(Messages.HouseUpdated);
        }
    }
}
