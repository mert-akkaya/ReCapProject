using Business.Abstract;
using Business.Constants;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTOs;
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

        public IDataResult<List<SavedCartDetailDto>> GetSavedCartDetail(int customerId)
        {
            return new SuccessDataResult<List<SavedCartDetailDto>>(_savedCreditCartDal.GetSavedCartDetail(c=>c.CustomerId==customerId));
        }
    }
}
