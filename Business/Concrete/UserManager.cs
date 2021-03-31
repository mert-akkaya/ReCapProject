using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Result;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using Entities.Concrete.DTOs;
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
        [ValidationAspect(typeof(UserValidator))]
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
            if (users.Count == 0)
            {
                return new ErrorDataResult<List<User>>(Messages.UsersNotListed);
            }
            else
            {
                return new SuccessDataResult<List<User>>(users, Messages.UsersListed);
            }

        }

        public IDataResult<User> GetByMail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email));
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }

        public IResult UpdateForProfile(UserForProfileUpdateDto userForProfileUpdateDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userForProfileUpdateDto.Password, out passwordHash, out passwordSalt);
            var updatedUser = new User
            {
                Id = userForProfileUpdateDto.Id,
                FirstName = userForProfileUpdateDto.FirstName,
                LastName = userForProfileUpdateDto.LastName,
                Email = userForProfileUpdateDto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = userForProfileUpdateDto.Status

            };
            _userDal.Update(updatedUser);
            return new SuccessResult(Messages.UserUpdated);
        }
    }
}
