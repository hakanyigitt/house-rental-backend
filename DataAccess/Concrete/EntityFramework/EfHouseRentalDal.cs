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
    public class EfHouseRentalDal : EfEntityRepositoryBase<HouseRental, HouseRentalContext>, IHouseRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<RentalDetailDto, bool>> filter = null)
        {
            using (HouseRentalContext context = new HouseRentalContext())
            {
                var result = from r in context.HouseRentals
                             join h in context.Houses on r.HouseId equals h.Id
                             join c in context.Cities on h.CityId equals c.Id
                             join ct in context.Categories on h.CategoryId equals ct.Id
                             join u in context.Users on r.UserId equals u.Id
                             select new RentalDetailDto
                             {
                                 HouseId = h.Id,
                                 CategoryName = ct.CategoryName,
                                 CityName = c.CityName,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 RentDate = r.RentalDate,
                                 ReturnDate = r.EndDate

                             };
                return filter == null
                    ? result.ToList()
                    : result.Where(filter).ToList();
            }
        }
    }
}
