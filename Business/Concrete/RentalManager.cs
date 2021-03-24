using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
           IResult result = BusinessRules.Run(ChechIfCarReturnDate(rental),CheckIfCarRentable(rental));
            if (result!=null)
            {
                return result;
            }
            else
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.RentalAdded);
            }
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<Rental> Get(int rentalId)
        {
            var rental = _rentalDal.Get(r => r.Id == rentalId);
            if (rental==null)
            {
                return new ErrorDataResult<Rental>(Messages.RentalIsNull);
            }
            else
            {
                return new SuccessDataResult<Rental>(rental, Messages.RentalsListed);
            }
        }

        public IDataResult<List<Rental>> GetAll()
        {
            var rentals = _rentalDal.GetAll();
            if (rentals.Count==0)
            {
                return new ErrorDataResult<List<Rental>>(Messages.RentalIsNull);
            }
            else
            {
                return new SuccessDataResult<List<Rental>>(rentals, Messages.RentalsListed);
            }
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetail()
        {
            var data = _rentalDal.GetRentalDetail();
            if (data.Count==0)
            {
                return new ErrorDataResult<List<RentalDetailDto>>();
            }
            else
            {
                return new SuccessDataResult<List<RentalDetailDto>>(data,Messages.RentalDetailListed);
            }

            
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
        private IResult ChechIfCarReturnDate(Rental rental)
        {
            var result = _rentalDal.GetAll(r => r.CarId == rental.CarId && r.ReturnDate == null);
            if (result.Count > 0)
            {
                return new ErrorResult(Messages.RentalNotAdded);
            }
            return new SuccessResult();
        }
        private IResult CheckIfCarRentable(Rental rental)
        {
            var result = _rentalDal.Get(r => r.CarId == rental.CarId);
            if (result!=null)
            {
                  if (rental.RentDate>result.ReturnDate)
                {
                    return new SuccessResult();
                }
                return new ErrorResult("This car cannot be rent");
            }
            else
            {
                return new SuccessResult();
            }
            
            
        }
    }
}
