using Models;
using System.Data;

namespace WebService.DAL.ModelFactory
{
    public class UserCreator : IModelCreator<User> 
    {
        public User CreateModel(IDataReader src)  
        {
            User user = new User()  
            {
                UserId = Convert.ToInt16(src["car_company_id"]),
                UserFirstName = Convert.ToString(src["Name"]),
                UserPassword = Convert.ToString(src["UserPassword"]),
                CityId = Convert.ToInt16(src["CityId"]),   
                Address = Convert.ToString(src["UserAddress"]),
                PhoneNum = Convert.ToString(src["PhoneNum"]),    
            };
            return user;  
        }
    }
}
