using Core.DataAccess.EntityFramework;
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
    public class EfSavedCreditCartDal : EfEntityRepositoryBase<SavedCreditCart, ReCapProjectContext>, ISavedCreditCartDal
    {
        

        public List<SavedCartDetailDto> GetSavedCartDetail(Expression<Func<SavedCreditCart, bool>> filter = null)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from savedCreditCart in filter == null ? context.SavedCreditCarts : context.SavedCreditCarts.Where(filter)
                             join creditCart in context.CreditCarts on savedCreditCart.CartId equals creditCart.Id
                             select new SavedCartDetailDto
                             {
                                 Id=savedCreditCart.Id,
                                 CartId = savedCreditCart.CartId,
                                 CustomerId = savedCreditCart.CustomerId,
                                 CartOwnerName = creditCart.CartOwnerName,
                                 CartNumber=creditCart.CartNumber,
                                 CartCvv=creditCart.CartCvv,
                                 CartDate=creditCart.CartDate
                             };

                return result.ToList();
            }
        }
    }
}
