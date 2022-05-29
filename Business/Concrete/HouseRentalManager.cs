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

        public IDataResult<bool> CheckIfCanHouseBeRentedBetweenSelectedDates(int houseId, DateTime rentDate, DateTime returnDate)
        {
            return CheckIfHouseAvailableBetweenSelectedDates(houseId, rentDate, returnDate);
        }

        private IDataResult<bool> CheckIfHouseAvailableBetweenSelectedDates(int houseId, DateTime rentDate, DateTime returnDate)
        {
            var allRentals = _houseRentalDal.GetAll(h => h.HouseId == houseId);

            foreach (var reservation in allRentals)
            {
                if ((rentDate >= reservation.RentalDate && rentDate <= reservation.EndDate) ||
                    (returnDate >= reservation.RentalDate && returnDate <= reservation.EndDate) ||
                    (reservation.RentalDate >= rentDate && reservation.RentalDate <= returnDate) ||
                    (reservation.EndDate >= rentDate && reservation.EndDate <= returnDate))
                {
                    return new ErrorDataResult<bool>(false, Messages.ReservationBetweenSelectedDatesExist);
                }
            }
            return new SuccessDataResult<bool>(true, Messages.HouseCanBeRentedBetweenSelectedDates);
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

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_houseRentalDal.GetRentalDetails());
        }

        public IResult Update(HouseRental houseRental)
        {
            _houseRentalDal.Update(houseRental);
            return new SuccessResult(Messages.HouseRentalUpdated);
        }

        public IDataResult<List<HouseRental>> GetAllById(int id)
        {
            return new SuccessDataResult<List<HouseRental>>(_houseRentalDal.GetAll(r => r.UserId == id));
        }
    }
}
