﻿using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer customer)
        {
            _customerDal.Add(new Customer { 
                UserId=customer.UserId,
                CompanyName=customer.CompanyName,
                FindexPoint=100
            });
            return new SuccessResult(Messages.CustomerAdded);
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.CustomerDeleted);
        }

        public IDataResult<Customer> Get(int customerId)
        {
            var customer = _customerDal.Get(c => c.Id == customerId);
            if (customer==null)
            {
                return new ErrorDataResult<Customer>(Messages.CustomerIsNull);
            }
            else
            {
                return new SuccessDataResult<Customer>(customer, Messages.CustomersListed);
            }
        }

        public IDataResult<List<Customer>> GetAll()
        {
            var customers = _customerDal.GetAll();
            if (customers.Count==0)
            {
                return new ErrorDataResult<List<Customer>>(Messages.CustomersNotListed);
            }
            else
            {
                return new SuccessDataResult<List<Customer>>(customers, Messages.CustomersListed);
            }
        }

        public IDataResult<Customer> GetCustomerByUserId(int userId)
        {
            var customer = _customerDal.Get(c => c.UserId == userId);
            if (customer==null)
            {
                return new ErrorDataResult<Customer>("You are not customer");
            }
            else
            {
                return new SuccessDataResult<Customer>(customer);
            }
        }

        public IDataResult<List<CustomerDetailDto>> GetCustomerDetail()
        {
            return new SuccessDataResult<List<CustomerDetailDto>>(_customerDal.GetCustomerDetail());
        }

        public IDataResult<List<CustomerDetailDto>> GetCustomerDetailById(int id)
        {
            return new SuccessDataResult<List<CustomerDetailDto>>(_customerDal.GetCustomerDetail(c => c.Id == id));
        }

        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }
    }
}
