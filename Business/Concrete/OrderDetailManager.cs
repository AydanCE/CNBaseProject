using Business.Abstract;
using Core.Helpers.Result.Abstract;
using Core.Helpers.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OrderDetailManager(IOrderDetailDal orderDetailDal) : IOrderDetailService
    {
        private readonly IOrderDetailDal _orderDetailDal = orderDetailDal;

        public IResult AddOrderDetail(OrderDetail orderDetail)
        {
            _orderDetailDal.Add(orderDetail);
            return new SuccessResult("Order Detail has been added");
        }

        public IDataResult<List<OrderDetailDto>> GetAllOrderDetails()
        {
            var result = _orderDetailDal.GetAllOrderDetails();
            if(result.Count > 0)
            {
                return new SuccessDataResult<List<OrderDetailDto>>(result, "List has been downloaded");
            }
            return new ErrorDataResult<List<OrderDetailDto>>(result, "Error occured");
        }
    }
}
