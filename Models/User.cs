using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class User
    {
        public int UserId { get; set; }
        public string? UserFirstName { get; set; }
        public string? UserPassword { get; set; }
        public int CityId { get; set; }    
        public string? Address { get; set; }
        public string? PhoneNum { get; set; }

    }
}
