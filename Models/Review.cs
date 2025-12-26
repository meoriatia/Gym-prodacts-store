using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int UserId { get; set; }
        public string? Title { get; set; }
        public int Rating { get; set; }
        public string? Description { get; set; }    
    }
}
