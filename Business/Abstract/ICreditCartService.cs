using Core.Utilities.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICreditCartService
    {
        IResult Add(CreditCart creditCart);
        IResult Delete(CreditCart creditCart);
        IDataResult<List<CreditCart>> GetAll();
        IDataResult<CreditCart> GetById(int id);
        IDataResult<CreditCart> GetCartByCartNumber(string cartNumber);
    }
}
