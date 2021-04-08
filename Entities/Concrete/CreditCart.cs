using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CreditCart:IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CartNumber { get; set; }
        public string CartOwnerName { get; set; }
        public int CartCvv { get; set; }
        public string CartDate { get; set; }
    }
}
