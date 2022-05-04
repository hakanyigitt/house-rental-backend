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
    public class HouseRentalManager : IHouseRentalService
    {
        IHouseRentalDal _houseRentalDal;
        public HouseRentalManager(IHouseRentalDal houseRentalDal)
        {
            _houseRentalDal = houseRentalDal;
        }

        public IResult Add(HouseRental houseRental)
        {
            _houseRentalDal.Add(houseRental);
            return new SuccessResult(Messages.HouseRentalAdded);
        }

        public IResult Delete(HouseRental houseRental)
        {
            _houseRentalDal.Delete(houseRental);
            return new SuccessResult(Messages.HouseRentalDeleted);
        }

        public IDataResult<List<HouseRental>> GetAll()
        {
            return new SuccessDataResult<List<HouseRental>>(_houseRentalDal.GetAll(), Messages.HouseRentalListed);
        }

        public IDataResult<HouseRental> GetById(int id)
        {
            return new SuccessDataResult<HouseRental>(_houseRentalDal.Get(r => r.Id == id));
        }

        public IResult Update(HouseRental houseRental)
        {
            _houseRentalDal.Update(houseRental);
            return new SuccessResult(Messages.HouseRentalUpdated);
        }
    }
}
