using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EF
{
    public class EfOrderDetailDal : BaseRepository<OrderDetail, BaseProjectContext>, IOrderDetailDal
    {
        public EfOrderDetailDal(BaseProjectContext context) : base(context)
        {

        }
        public List<OrderDetailDto> GetAllOrderDetails()
        {
            var context = new BaseProjectContext();
            var result = from d in context.OrderDetails
                         where d.IsDelete == false
                         join o in context.Orders
                         on d.OrderId equals o.Id
                         join t in context.Tours
                         on d.TourId equals t.Id
                         select new OrderDetailDto()
                         {
                             OrderId = o.Id,
                             OrderDate = o.OrderDate,
                             IsDelivery = o.IsDelivery,
                             TourName = t.TourName,
                             TourPrice = t.TourPrice,
                             DiscountPriceRate = d.DiscountPriceRate,
                             IsDiscount = d.IsDiscount,
                             Count = d.Count
                         };
            return result.ToList();
        }
    }
}
