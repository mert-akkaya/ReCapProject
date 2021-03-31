using Core.Utilities.Result;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll();
        IDataResult<Customer> Get(int customerId);
        IDataResult<Customer> GetCustomerByUserId(int userId);
        IResult Add(Customer customer);
        IResult Update(Customer customer);
        IResult Delete(Customer customer);
        IDataResult<List<CustomerDetailDto>> GetCustomerDetail();
        IDataResult<List<CustomerDetailDto>> GetCustomerDetailById(int id);
    }
}
