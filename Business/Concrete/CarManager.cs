using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Performance;
using Core.Aspect.Autofac.Transaction;
using Core.Aspect.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [SecuredOperation("car.add")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            if (car.DailyPrice<15)
            {
                return new ErrorResult();
            }
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);

        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetail()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetail(), Messages.CarDetailListed);
        }
        public IDataResult<List<CarDetailDto>> GetCarDetailById(int ıd)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetail(c=>c.Id==ıd), Messages.CarDetailListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailByBrand(int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetail(c => c.BrandId == brandId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailByColor(int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetail(c => c.ColorId == colorId));
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(b => b.BrandId == brandId));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId));
        }
        [TransactionScopeAspect]
        public IResult TransactionTest(Car car)
        {
            _carDal.Update(car);
            _carDal.Add(car);
            return new SuccessResult();
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        public IDataResult<List<CarDetailDto>> GetCarByBrandAndColor(int brandId, int colorId)
        {
           var result = _carDal.GetCarDetail(c=>c.BrandId==brandId && c.ColorId==colorId);
            if (result == null)
            {
                return new ErrorDataResult<List<CarDetailDto>>("cars not listed for brand and color");
            }
            else
            {
                return new SuccessDataResult<List<CarDetailDto>>(result,"cars listed for brand and color");
            }
            
        }
    }
}
