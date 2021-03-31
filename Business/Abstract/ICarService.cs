using Core.Utilities.Result;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface ICarService
    {
       
        IDataResult< List<Car>> GetAll();
        IDataResult<Car> GetById(int id);
        IDataResult<List<Car>> GetCarsByBrandId(int brandId);
        IDataResult<List<Car>> GetCarsByColorId(int colorId);
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IDataResult<List<CarDetailDto>> GetCarDetail();
        IDataResult<List<CarDetailDto>> GetCarDetailById(int ıd);
        IDataResult<List<CarDetailDto>> GetCarDetailByBrand(int brandId);
        IDataResult<List<CarDetailDto>> GetCarDetailByColor(int colorId);
        IDataResult<List<CarDetailDto>> GetCarByBrandAndColor(int brandId,int colorId);

        IResult TransactionTest(Car car);
    }
}
