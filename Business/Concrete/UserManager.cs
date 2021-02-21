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
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<User> Get(int userId)
        {
           var user = _userDal.Get(u => u.Id == userId);
            if (user == null)
            {
                return new ErrorDataResult<User>(Messages.UserIsNull);
            }
            else
            {
                return new SuccessDataResult<User>(user, Messages.UsersListed);
            }
        }

        public IDataResult<List<User>> GetAll()
        {
            var users = _userDal.GetAll();
            if (users.Count==0)
            {
                return new ErrorDataResult<List<User>>(Messages.UsersNotListed);
            }
            else
            {
                return new SuccessDataResult<List<User>>(users,Messages.UsersListed);
            }
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }
    }
}
