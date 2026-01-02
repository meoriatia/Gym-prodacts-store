using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ProductCatalogViewModel
    {
        public List<Product> Products { get; set; }
        public List<Material> Materials { get; set; }
        public List<Brand> Brands { get; set; }

        public int Raitings = 10;
        public int UsersRaitings { get; set; }
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }



    }
}
