using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
   public class InMemoryDal : ICarDal
    {
        List<Car> _cars;
       
        public InMemoryDal()
        {
            _cars = new List<Car>
            {
                new Car{Id=1,BrandId=1,ColorId=1,DailyPrice=100,ModelYear="2000",Description="Red Car"},
                new Car{Id=2,BrandId=1,ColorId=2,DailyPrice=150,ModelYear="2010",Description="Black Car"},
                new Car{Id=3,BrandId=2,ColorId=1,DailyPrice=200,ModelYear="2020",Description="White Car"},
                new Car{Id=4,BrandId=3,ColorId=3,DailyPrice=400,ModelYear="2018",Description="Yellow Car"}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
            Console.WriteLine("Car added : "+car.Description);
        }

        public void Delete(Car car)
        {
            var carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
            Console.WriteLine("Car deleted : " + car.Description);
        }

        public List<Car> GetAll()
        {
            return _cars.ToList();
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(c=>c.Id==id).ToList();
        }

        public void Update(Car car)
        {
            var carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.Id = car.Id;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
            Console.WriteLine("Car updated : " + car.Description);
        }
    }
}
