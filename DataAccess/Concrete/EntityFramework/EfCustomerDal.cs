﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, ReCapProjectContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetail(Expression<Func<Customer, bool>> filter = null)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from customer in filter == null ? context.Customers : context.Customers.Where(filter)
                             join user in context.Users on customer.UserId equals user.Id
                             select new CustomerDetailDto
                             {
                                 CustomerId = customer.Id,
                                 CompanyName = customer.CompanyName,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName


                             };
                return result.ToList();
            }
        }
    }
}
