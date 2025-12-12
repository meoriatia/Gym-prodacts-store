using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    internal class Product
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductTypeId { get; set; }
        public string? ProductPhoto { get; set; }
        public bool Flavored { get; set; }  
    }
}
