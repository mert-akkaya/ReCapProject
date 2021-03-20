using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Payment:IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CartNumber { get; set; }
        public int CartCvv { get; set; }
        public int Price { get; set; }
    }
}
