using Business.Abstract;
using Core.Helpers.Result.Abstract;
using Core.Helpers.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OrderManager(IOrderDal orderDal) : IOrderService
    {
        private readonly IOrderDal _orderDal = orderDal;

        public IResult AddOrder(Order order)
        {
            _orderDal.Add(order);
            return new SuccessResult("Order has been added");
        }

        public IResult DeleteOrder(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Order>> GetAllOrders()
        {
            var result = _orderDal.GetAll(o => o.IsDelete == false);
            if(result.Count > 0)
            {
                return new SuccessDataResult<List<Order>>(result);
            }
            return new ErrorDataResult<List<Order>>(result);
        }

        public IDataResult<Order> GetOrder(int id)
        {
            throw new NotImplementedException();
        }
    }
}
