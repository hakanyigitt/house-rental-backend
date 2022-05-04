using Business.Abstract;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concreate;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concreate
{
    public class HouseImageManager : IHouseImageService
    {
        IHouseImageDal _houseImageDal;

        public HouseImageManager(IHouseImageDal houseImageDal)
        {
            _houseImageDal = houseImageDal;
        }

        [ValidationAspect(typeof(HouseImageValidator))]
        public IResult Add(IFormFile file, HouseImage houseImage)
        {
            IResult result = BusinessRules.Run(CheckIfHouseImageLimitExceeded(houseImage.HouseId));

            if (result != null)
            {
                return result;
            }

            houseImage.ImagePath = FileHelper.Add(file);
            _houseImageDal.Add(houseImage);
            return new SuccessResult();
        }    

        public IResult Delete(HouseImage houseImage)
        {
            var path = Environment.CurrentDirectory + @"\wwwroot\" + houseImage.ImagePath;
            FileHelper.Delete(path);
            _houseImageDal.Delete(houseImage);
            return new SuccessResult(Messages.HouseImageDeleted);
        }

        public IDataResult<List<HouseImage>> GetAll()
        {
            return new SuccessDataResult<List<HouseImage>>(_houseImageDal.GetAll());
        }

        public IDataResult<List<HouseImage>> GetByHouseId(int houseId)
        {
            return new SuccessDataResult<List<HouseImage>>(CheckIfAnyHouseImageExists(houseId));
        }

        private List<HouseImage> CheckIfAnyHouseImageExists(int houseId)
        {
            string path = @"\images\DefaultHouse.jpg";
            var result = _houseImageDal.GetAll(c => c.HouseId == houseId).Any();

            if (result)
            {
                return _houseImageDal.GetAll(p => p.HouseId == houseId);
            }
            return new List<HouseImage> { new HouseImage { HouseId = houseId, ImagePath = path} };
        }

        public IDataResult<HouseImage> GetById(int id)
        {
            var result = _houseImageDal.Get(c => c.Id == id);
            return new SuccessDataResult<HouseImage>(result);
        }

        [ValidationAspect(typeof(HouseImageValidator))]
        public IResult Update(IFormFile file, HouseImage houseImage)
        {
            houseImage.ImagePath = FileHelper.Update(Environment.CurrentDirectory + @"\wwwroot\" + _houseImageDal.Get(p => p.Id == houseImage.Id).ImagePath, file);
            _houseImageDal.Update(houseImage);
            return new SuccessResult(Messages.HouseImageUpdated);
        }

        private IResult CheckIfHouseImageLimitExceeded(int houseId)
        {
            var houseImageCount = _houseImageDal.GetAll(p => p.HouseId == houseId).Count;
            if(houseImageCount >= 5)
            {
                return new ErrorResult(Messages.HouseImageLimitExceeded);
            }
            return new SuccessResult();
        }
    }
}
