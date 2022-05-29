using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concreate
{
    public class House:IEntity
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int CityId { get; set; }
        public string Address { get; set; } 
        public int Size { get; set; }
        public int FloorLocation { get; set; }
        public decimal DailyPrice { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
    }
}
