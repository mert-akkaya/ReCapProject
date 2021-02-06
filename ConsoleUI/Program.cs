using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Car ıd : "+car.Id);
                Console.WriteLine("Car color ıd : "+car.ColorId);
                Console.WriteLine("Car brand ıd : "+car.BrandId);
                Console.WriteLine("Car daily price : "+car.DailyPrice);
                Console.WriteLine("Car model year : "+car.ModelYear);
                Console.WriteLine("Car description : "+car.Description);
                Console.WriteLine("----------------");
                
            }

            foreach (var carByBrand in carManager.GetCarsByBrandId(2))
            {
                Console.WriteLine(carByBrand.Description);
                Console.WriteLine("-------------");
            }
            foreach (var carByColor in carManager.GetCarsByColorId(1))
            {
                Console.WriteLine(carByColor.Description);
                Console.WriteLine("--------------");
            }
            carManager.Add(new Car { BrandId = 2, ColorId = 4, DailyPrice = 0, Description = "White bmw car", ModelYear = "2020" });

           
        }
    }
}
