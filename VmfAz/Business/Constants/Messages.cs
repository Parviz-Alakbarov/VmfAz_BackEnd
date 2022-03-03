using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        //Product Messages
        public static readonly string ProductAdded = "Product Added Successfully!";
        public static readonly string ProductsListedSuccessfully = "Products Listed Successfully!"; 

        //Brand Messages
        public static readonly string BrandAdded = "Brand Added Successfully!";

        //User Messages 

        public const string UserRegistered = "User Registered Successfully";
        public const string UserNotFound = "Username or Password is Incorrect!";
        public const string PasswordError = "Username or Password is Incorrect!";
        public const string SuccessfulLogin = "User Loged in Succesfully";
        public const string UserAlreadyExists = "User Already Exist!";
        public const string AccessTokenCreated = "Token Created Successfully!";
        public const string ChangePasswordError = "Your Current Password Is Incorrect!";
    }
}
