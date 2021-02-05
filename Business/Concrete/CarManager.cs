using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        public void Add(Car car)
        {
            //iş kodları yazıldı
            _carDal.Add(car);
        }

        public void Delete(Car car)
        {
            //iş kodları yazıldı
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            //iş kodları yazıldı
           return _carDal.GetAll();
        }

        public List<Car> GetById(int id)
        {
            //iş kodları yazıldı
            
            return _carDal.GetById(id);
        }

        public void Update(Car car)
        {
            //iş kodları yazıldı
            _carDal.Update(car);
        }
    }
}
