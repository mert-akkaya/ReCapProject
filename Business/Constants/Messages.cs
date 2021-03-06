﻿using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Car added";
        public static string CarDeleted = "Car deleted";
        public static string CarUpdated = "Car updated";
        public static string CarNameInvalid = "Car name invalid";
        public static string MaintenanceTime = "System is under maintenance";
        public static string CarsListed = "Cars listed";
        public static string CarDetailListed = "Car detail listed";

        public static string BrandAdded = "Brand added";
        public static string BrandDeleted = "Brand deleted";
        public static string BrandUpdated = "Brand updated";
        public static string BrandsListed = "Brands listed";

        public static string ColorAdded = "Color added";
        public static string ColordDeleted = "Color deleted";
        public static string ColorUpdated = "Color updated";

        public static string UserAdded = "User added";
        public static string UserDeleted = "User deleted";
        public static string UserUpdated = "User updated";
        public static string UserIsNull = "User is not found";
        public static string UsersListed = "Users listed ";
        public static string UsersNotListed= "There is no user";

        public static string CustomerAdded = "Customer added";
        public static string CustomerDeleted = "Customer deleted";
        public static string CustomerUpdated = "Customer updated";
        public static string CustomerIsNull = "Customer is not found";
        public static string CustomersListed = "Customers listed";
        public static string CustomersNotListed = "There is no user";


        public static string RentalAdded = "Rental added";
        public static string RentalNotAdded = "This car cannot be rented";
        public static string RentalDeleted = "Rental deleted";
        public static string RentalUpdated ="Rental updated";
        public static string RentalIsNull = "Rental is not found";
        public static string RentalsListed = "Rentals listed";
        public static string RentalsNotListed = "There is no rental";
        public static string RentalDetailListed = "Rental detail listed";
        public static string CarImageLimitExceed= "A car can have up to 5 images";
        public static string UserNotFound="User not found";
        public static string PasswordError="Password error";
        public static string SuccessfulLogin="Login succes";
        public static string UserAlreadyExists="User already exist";
        public static string UserRegistered="User registered";
        public static string AccessTokenCreated="Access token created";
        public static string AuthorizationDenied = "You are not authorized";
        public static string InsufficientFindexPoint = "Findex point insufficient";

        public static string CartSaved = "Cart saved";
        public static string CartDeleted = "Cart deleted";

    }
}
