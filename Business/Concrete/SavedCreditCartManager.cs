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
   public class SavedCreditCartManager:ISavedCreditCartService
    {
        ISavedCreditCartDal _savedCreditCartDal;
        public SavedCreditCartManager(ISavedCreditCartDal savedCreditCartDal)
        {
            _savedCreditCartDal = savedCreditCartDal;
        }
        public IResult Add(SavedCreditCart creditCart)
        {
            _savedCreditCartDal.Add(creditCart);
            return new SuccessResult(Messages.CartSaved);
        }

        public IResult Delete(SavedCreditCart creditCart)
        {
            _savedCreditCartDal.Delete(creditCart);
            return new SuccessResult(Messages.CartDeleted);
        }

        public IDataResult<List<SavedCreditCart>> GetAll()
        {
            var result = _savedCreditCartDal.GetAll();
            return new SuccessDataResult<List<SavedCreditCart>>(result, "Listed");
        }

        public IDataResult<SavedCreditCart> GetById(int id)
        {
            var result = _savedCreditCartDal.Get(c => c.Id == id);
            return new SuccessDataResult<SavedCreditCart>(result);
        }
    }
}
