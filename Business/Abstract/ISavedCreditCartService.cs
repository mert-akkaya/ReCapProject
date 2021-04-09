using Core.Utilities.Result;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ISavedCreditCartService
    {
        IResult Add(SavedCreditCart creditCart);
        IResult Delete(SavedCreditCart creditCart);
        IDataResult<List<SavedCreditCart>> GetAll();
        IDataResult<SavedCreditCart> GetById(int id);
        IDataResult<List<SavedCartDetailDto>> GetSavedCartDetail(int customerId);
    }
}
