using Core.DataAccess;
using Entities.Concreate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IHouseRentalDal : IEntityRepository<HouseRental>
    {
        List<RentalDetailDto> GetRentalDetails(Expression<Func<RentalDetailDto, bool>> filter = null);
    }
}
