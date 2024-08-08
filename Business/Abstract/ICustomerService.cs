using Core.Helpers.Result.Abstract;
using Core.Helpers.Result.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IResult Add(Customer customer);
        IResult Update(Customer customer);
        IResult Delete(int id);
        IDataResult<List<Customer>>GetAllCustomer();
        IDataResult<Customer> GetCustomer(int id);
    }
}
