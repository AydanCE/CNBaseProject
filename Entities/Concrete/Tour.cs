using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Tour : BaseEntity
    {
        public string TourName { get; set; }
        public string Description { get; set; }
        public decimal TourPrice { get; set; }
        public bool IsDiscount {  get; set; }
        public int DiscountRate { get; set; }
    }
}
