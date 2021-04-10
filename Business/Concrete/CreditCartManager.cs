using Business.Abstract;
using Business.Constants;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CreditCartManager : ICreditCartService
    {
        ICreditCartDal _creditCartDal;
        public CreditCartManager(ICreditCartDal creditCartDal)
        {
            _creditCartDal = creditCartDal;
        }
        public IResult Add(CreditCart creditCart)
        {
            _creditCartDal.Add(creditCart);
            return new SuccessResult(Messages.CartSaved);
        }

        public IResult Delete(CreditCart creditCart)
        {
            _creditCartDal.Delete(creditCart);
            return new SuccessResult(Messages.CartDeleted);
        }

        public IDataResult<List<CreditCart>> GetAll()
        {
           var result = _creditCartDal.GetAll();
            return new SuccessDataResult<List<CreditCart>>(result, "Listed");
        }

        public IDataResult<CreditCart> GetById(int id)
        {
            var result = _creditCartDal.Get(c => c.Id == id);
            return new SuccessDataResult<CreditCart>(result);
        }

        public IDataResult<CreditCart> GetCartByCartNumber(string cartNumber)
        {
            var result = _creditCartDal.Get(c => c.CartNumber == cartNumber);
            if (result==null)
            {
                new ErrorDataResult<CreditCart>();
            }
            return new SuccessDataResult<CreditCart>(result);
        }
    }
}
