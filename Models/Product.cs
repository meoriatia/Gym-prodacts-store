using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public int Price { get; set; }
        public int ProductTypeId { get; set; }
        public string? ProductPhoto { get; set; }
        public bool Flavored { get; set; }  
    }
}
