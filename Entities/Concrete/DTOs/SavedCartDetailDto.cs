using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete.DTOs
{
    public class SavedCartDetailDto:IDto
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public int CustomerId { get; set; }
        public string CartOwnerName { get; set; }
        public string CartNumber { get; set; }
        public string CartDate { get; set; }
        public int CartCvv { get; set; }
    }
}
