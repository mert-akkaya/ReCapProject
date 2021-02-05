using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryDal());

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

            foreach (var carById in carManager.GetById(2))
            {
                Console.WriteLine("Match results : ");
                Console.WriteLine("Car ıd : " + carById.Id);
                Console.WriteLine("Car color ıd : " + carById.ColorId);
                Console.WriteLine("Car brand ıd : " + carById.BrandId);
                Console.WriteLine("Car daily price : " + carById.DailyPrice);
                Console.WriteLine("Car model year : " + carById.ModelYear);
                Console.WriteLine("Car description : " + carById.Description);
            }
            //istenilirse diğer metodlar da çağırılabilir(Add,Update,Delete)
        }
    }
}
