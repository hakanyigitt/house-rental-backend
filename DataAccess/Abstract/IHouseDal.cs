using Core.DataAccess;
using Entities.Concreate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IHouseDal : IEntityRepository<House>
    {
        List<HouseDetailDto> GetHouseDetails(Expression<Func<HouseDetailDto, bool>> filter = null);
    }
}
