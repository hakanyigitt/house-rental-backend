using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concreate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concreate.EntityFramework
{
    public class EfHouseDal : EfEntityRepositoryBase<House, HouseRentalContext>, IHouseDal
    {
        public List<HouseDetailDto> GetHouseDetails(Expression<Func<HouseDetailDto, bool>> filter = null)
        {
            using (HouseRentalContext context = new HouseRentalContext())
            {
                var result = from h in context.Houses
                             join c in context.Cities
                             on h.CityId equals c.Id
                             join ct in context.Categories
                             on h.CategoryId equals ct.Id
                             select new HouseDetailDto
                             {
                                 HouseId = h.Id,
                                 CategoryId = ct.Id,
                                 CityId = c.Id,
                                 HouseName = h.Description,
                                 CategoryName = ct.CategoryName,
                                 CityName = c.CityName,
                                 Address = h.Address,
                                 DailyPrice = h.DailyPrice,
                                 FloorLocation = h.FloorLocation,
                                 size = h.Size,
                                 Status = h.Status,
                                 HouseImagePath = (from i in context.HouseImages where i.HouseId == h.Id select i.ImagePath).ToList()
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
