using Models;
using System.Data;

namespace WebService.DAL
{
    public class UserCreator : IModelCreator<User> 
    {
        public User CreateModel(IDataReader src)  
        {
            User user = new User()  
            {
                UserId = Convert.ToInt16(src["UserId"]),
                UserFirstName = Convert.ToString(src["UserFirstName"]),
                UserPassword = Convert.ToString(src["UserPassword"]),
                CityId = Convert.ToInt16(src["CityId"]),   
                Address = Convert.ToString(src["Address"]),
                PhoneNum = Convert.ToString(src["PhoneNum"]),    
            };
            return user;  
        }
    }
}
