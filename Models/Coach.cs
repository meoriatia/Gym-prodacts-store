using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Coach
    {
        public int CoachId { get; set; }    
        public int CoachSecurityNum { get; set; }   
        public  string? CoachFirstName { get; set; }  
        public string? CoachPicture { get; set; }
        public string? CoachLastName { get; set; }
    }
}
