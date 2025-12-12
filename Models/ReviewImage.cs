using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    internal class ReviewImage
    {
        public int ReviewImageId { get; set; }
        public int ReviewId { get; set; }
        public string? Description { get; set; } 
        public string? ImageName { get; set; }   

    }
}
