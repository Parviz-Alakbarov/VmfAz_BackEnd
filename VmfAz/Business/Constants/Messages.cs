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
        public static readonly string ProductNotFound = "Product Not Found!";
        public static readonly string ProductAlreadyExists = "Product name alreary exist";
        public static readonly string ProductDeletedSuccessfully = "Product deleted successfully!";
        public static readonly string ProductUpdatedSuccesfully = "Product updated successfully!";
        public static readonly string ProductUndeletedSuccessfully = "Product Undeleted successfully!";
        public static readonly string EntriesListed = "Product Entries Listed.";

        //Product Image Messages
        public static readonly string ProductImageAddedSuccessfully = "Product Image Added Successfully!";
        public static readonly string ProductImageNotFound = "Product Image Not Found!";
        public static readonly string ProductImagesListedSuccessfully = "Product Images Listed Successfully!";
        public static readonly string ProductImageLimitExceeded = "Product Image Limit Exceeded!";
        public static readonly string ProductImageUpdatedSuccessfully = "Product Image Updated Successfully!";
        public static readonly string ErrorDeletingImage = "Error occurred while image deletion!";
        public static readonly string ProductimageDeletedSuccessfully = "Product Image Deleted Successfully!";

        //Brand Messages
        public static readonly string BrandAdded = "Brand Added Successfully!";
        public static readonly string BrandsListedSuccessfully = "Brands Listed Successfully!";
        public static readonly string BrandNotFound = "Brand Not Found!";
        public static readonly string BrandAlreadyExists = "Brand name alreary exist";
        public static readonly string BrandDeletedSuccessfully = "Brand deleted successfully!";
        public static readonly string BrandUpdatedSuccesfully = "Brand updated successfully!";
        public static readonly string BrandUndeletedSuccessfully = "Brand Undeleted successfully!";


        //User Messages 

        public static readonly string UserRegistered = "User Registered Successfully";
        public static readonly string UserNotFound = "Username or Password is Incorrect!";
        public static readonly string PasswordError = "Username or Password is Incorrect!";
        public static readonly string SuccessfullLogin = "User Loged in Succesfully";
        public static readonly string UserAlreadyExists = "User Already Exist!";
        public static readonly string UserDataFound = "User Data Found!";
        public static readonly string AccessTokenCreated = "Token Created Successfully!";
        public static readonly string ChangePasswordError = "Your Current Password Is Incorrect!";
        public static readonly string RefreshTokenCreated = "Refresh Token Created Successfully!";
        public static readonly string RefreshTokenDeleted = "Refresh Token Deleted Successfully!";
        public static readonly string RefreshTokenNotFound = "Refresh Token Not Found!";
        public static readonly string RefreshTokenAdded = "Refresh Token Added.";
        public static readonly string UserLoggedOut = "User Successfully Logged out.";
        public static readonly string InvalidRefreshToken = "Invalid Refresh token!";
        public static readonly string TokenRefreshed = "Token Refresed Successfully";
        public static readonly string RefreshTokenCreationError = "Error accured while refresh token creation";
        public static readonly string ClaimNotFound = "Claim Not Found!";
        public static readonly string ClaimAddedToUser = "Claim added to user!";



        //BasketItem Messages
        public static readonly string ProductAddedToBasket = "Product Added to Basket Successfully!";
        public static readonly string BasketItemNotFound = "Basket Item Not Found!";
        public static readonly string BasketItemLimitExceeded = "You can buy up to 10 items.";
        public static readonly string BasketItemDeletedSuccessfully = "Basket item Deleted Successfully!";

        //City and Country Messages 
        public static readonly string CityNotExist = "City Not fount!";
        public static readonly string CitiesListed = "Cities Listed Successfully!";
        public static readonly string CountriesListed = "Countries Listed Successfully!";

        //Setting Messages
        public static readonly string SettingUpdated = "Setting Updated Successfully";
        public static readonly string SettingAlreadyExist = "Setting Key Already Exists!";
        public static readonly string SettingListed = "Settings Listed Successfully"!;
        public static readonly string SettingDataNotFound = "Setting Data not Found!";


        //Slider Messages
        public static readonly string SliderImageIsRequired = "Slider Image is Required!";
        public static readonly string SliderAddedSuccessfully = "Slider Added Successfully!";
        public static readonly string SliderNotFound = "Slider Not Found!";
        public static readonly string SliderDeletedSuccessfully = "Slider Deleted Successfully!";
        public static readonly string SliderUpdatedSuccessfully = "Slider Updated Successfully!";

        //Shop Messsages
        public static readonly string ShopAdded = "Shop Added Successfully";
        public static readonly string ShopListed = "Shop Listed Successfully";
        public static readonly string ShopNotFound = "Shop Not Found!";
        public static readonly string ShopDeleted = "Shop Deleted Successfully!";
        public static readonly string ShopUpdated = "Shop Updated Successfully!";

        //Order Messages 
        public static readonly string OrderAdded = "Order created Successfully!";
        public static readonly string OrderNotFound = "Order Not Found";
        public static readonly string OrderUpdated = "Order Upddated Successfully";
        public static readonly string OrdersListed = "Orders Listed Successfully";
        public static readonly string OrderFound = "Order Found";

        //Color
        public static readonly string ColorsListed = "Colors Listed Successfully.";
    }
}
