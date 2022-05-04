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
        public string Address { get; set; }
        public string City { get; set; }
        public int size { get; set; }
        public int FloorLocation { get; set; }
        public decimal DailyPrice { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
    }
}
