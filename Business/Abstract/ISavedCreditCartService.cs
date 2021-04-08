using Core.Utilities.Result;
using Entities.Concrete;
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
    }
}
