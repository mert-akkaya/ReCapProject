using Core.Entities.Concrete;
using Core.Utilities.Result;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IDataResult<User> Get(int userId);
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
        IResult UpdateForProfile(UserForProfileUpdateDto userForProfileUpdateDto);
        IDataResult<List<OperationClaim>> GetClaims(User user);
        IDataResult<User> GetByMail(string email);
    }
}
