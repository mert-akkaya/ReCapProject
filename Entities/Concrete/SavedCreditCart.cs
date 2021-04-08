using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class SavedCreditCart:IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int CartId { get; set; }

    }
}
