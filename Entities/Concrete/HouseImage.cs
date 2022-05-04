using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concreate
{
    public class HouseImage:IEntity
    {
        public int Id { get; set; }
        public int HouseId { get; set; }
        public string ImagePath { get; set; }
    }
}
