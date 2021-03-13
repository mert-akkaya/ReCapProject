using Business.Concrete;
using Core.Entities.Concrete;
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

            // BrandTest(1,"Wolsvagen");
            //CarTest();
            //ColorTest(1, "Dark Blue");
            //CustomerAdd();
            //UserAdd();
            //RentalTest();
            RentalAdd();
        }
        private static void CustomerAdd()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            
            Console.WriteLine(customerManager.Add(new Customer { UserId = 1002, CompanyName = "Akkaya A.Ş" }).Message);
        }
        private static void UserAdd()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            //userManager.Add(new User { FirstName = "Engin", LastName = "Demiroğ", Email = "engin@gmail.com", Password = "12345" });
        }
        private static void RentalAdd()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Console.WriteLine(rentalManager.Add(new Rental { CarId = 2, CustomerId = 17, RentDate = DateTime.Now, ReturnDate = null }).Message);
        }
        private static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Console.WriteLine(rentalManager.Add(new Rental { CarId = 2, CustomerId = 2, RentDate = DateTime.Now, ReturnDate = null }).Message);

        }
        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine("Car ıd : " + car.Id);
            //    Console.WriteLine("Car color ıd : " + car.ColorId);
            //    Console.WriteLine("Car brand ıd : " + car.BrandId);
            //    Console.WriteLine("Car daily price : " + car.DailyPrice);
            //    Console.WriteLine("Car model year : " + car.ModelYear);
            //    Console.WriteLine("Car description : " + car.Description);
            //    Console.WriteLine("----------------");

            //}

            //foreach (var carByBrand in carManager.GetCarsByBrandId(2))
            //{
            //    Console.WriteLine(carByBrand.Description);
            //    Console.WriteLine("-------------");
            //}
            //foreach (var carByColor in carManager.GetCarsByColorId(1))
            //{
            //    Console.WriteLine(carByColor.Description);
            //    Console.WriteLine("--------------");
            //}
            //Car car1 = new Car { BrandId = 2, ColorId = 4, DailyPrice = 0, Description = "White bmw car", ModelYear = "2020" };
            //carManager.Add(car1);
            // carManager.Delete(car1);
            // carManager.Update(car1);
            
            //var result = carManager.GetCarDetail();
            //if (result.Success)
            //{
            //    foreach (var car in result.Data)
            //    {
            //        Console.WriteLine(car.CarName + "/" + car.BrandName + "/" + car.ColorName + "/" + car.DailyPrice);
            //    }
            //    Console.WriteLine(result.Message);
            //}
            //else
            //{
            //    Console.WriteLine(result.Message);
            //}
            
            
        }
        private static void BrandTest(int brandId,string brandName)
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result = brandManager.GetAll();
            foreach (var brand in result.Data)
            {
                Console.WriteLine(brand.BrandName);
                Console.WriteLine("----------");
            }
            
            Brand brand1 = new Brand { BrandName = brandName };
            brandManager.Add(brand1);
            var getBrandId = brandManager.Get(brandId);
            Console.WriteLine("Brand is : "+getBrandId.Data.BrandName);
        }
        private static void ColorTest(int colorId,string colorName)
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var result = colorManager.GetAll();
            foreach (var color in result.Data)
            {
                Console.WriteLine(color.ColorName);
                Console.WriteLine("-----------");
            }
            Color color1 = new Color {ColorName=colorName };
            colorManager.Add(color1);
            var getColorId = colorManager.Get(colorId);
            Console.WriteLine("Color is : "+getColorId.Data.ColorName);
            
        }
    }
}
