using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concreate
{
    public class HouseRental:IEntity
    {
        public int Id { get; set; }
        public int HouseId { get; set; }
        public int UserId { get; set; }
        public int DayToStay { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
