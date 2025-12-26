using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ProductPurchcase
    {
        public int PurchaseId { get; set; }
        public int ProductId { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }  
    }
}
