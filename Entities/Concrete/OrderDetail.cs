using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class OrderDetail : BaseEntity
    {
        public int OrderId { get; set; }
        public int TourId { get; set; }
        public decimal TotalPrice { get; set; }
        public int Count { get; set; }
        public bool IsDiscount {  get; set; }
        public int DiscountPriceRate { get; set; }
    }
}
