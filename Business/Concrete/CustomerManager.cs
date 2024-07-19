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
    public class CustomerManager(ICustomerDal customerDal) : ICustomerService
    {
        private readonly ICustomerDal _customerDal = customerDal;
        public IResult Add(Customer customer)
        {
            if(customer.FirstName.Length >= 4)
            {
                _customerDal.Add(customer);
                return new SuccessResult($"{customer.FirstName} has been added");
            }
            return new ErrorResult($"{customer.FirstName} cannot be added!");
        }
        public IResult Delete(Customer customer)
        {
            Customer deleteCustomer = null;
            Customer resultCustomer = _customerDal.Get(c=>c.Id ==  customer.Id && c.IsDelete == false);
            if(resultCustomer != null)
            {
                deleteCustomer = resultCustomer;
                deleteCustomer.IsDelete = true;
                _customerDal.Delete(deleteCustomer);
                return new SuccessResult($"{customer.FirstName} has been deleted");
            }
            return new ErrorResult($"{customer.FirstName} is not found");
        }
        public IResult Update(Customer customer)
        {
            Customer updateCustomer = _customerDal.Get(c => c.Id == customer.Id && c.IsDelete == false);
            if(updateCustomer != null)
            {
                updateCustomer.FirstName = customer.FirstName;
                updateCustomer.LastName = customer.LastName;
                updateCustomer.PhoneNumber = customer.PhoneNumber;
                updateCustomer.Email = customer.Email;
                _customerDal.Update(updateCustomer);
                return new SuccessResult($"{customer.FirstName} has been updated");
            }
            return new ErrorResult($"{customer.FirstName} is not found");
        }
        public IDataResult<List<Customer>> GetAllCustomer()
        {
            var customers = _customerDal.GetAll(c => c.IsDelete == false).ToList();
            if(customers.Count != 0)
            {
                return new SuccessDataResult<List<Customer>>(customers);
            }
            return new ErrorDataResult<List<Customer>>("Error occured!");
        }
        public IDataResult<Customer> GetCustomer(Customer customer)
        {
            Customer getCustomer = _customerDal.Get(c => c.Id == customer.Id && c.IsDelete == false);
            if(getCustomer != null)
            {
                return new SuccessDataResult<Customer>(getCustomer, $"{customer.FirstName} has been gotten");
            }
            return new ErrorDataResult<Customer>($"{customer.FirstName} is not found");
        }
    }
}
