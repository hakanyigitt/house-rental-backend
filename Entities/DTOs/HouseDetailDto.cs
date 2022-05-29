using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class HouseDetailDto : IDto
    {
        public int HouseId { get; set; }
        public int CategoryId { get; set; }
        public int CityId { get; set; }
        public List<string> HouseImagePath { get; set; }
        public string HouseName { get; set; }
        public string CategoryName { get; set; }
        public string CityName { get; set; }
        public string Address { get; set; }
        public int size { get; set; }
        public int FloorLocation { get; set; }
        public decimal DailyPrice { get; set; }
        public bool Status { get; set; }
    }
}
