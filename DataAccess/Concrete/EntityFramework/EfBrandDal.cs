using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : IBrandDal
    {
        public void Add(Brand entity)
        {
           
        }

        public void Delete(Brand entity)
        {
            
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            return null;
        }

        public void Update(Brand entity)
        {
           
        }
    }
}
