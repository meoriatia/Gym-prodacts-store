using Models;
using System.Data;

namespace WebService.DAL
{
    public class ProductPurchaseCreator : IModelCreator<ProductPurchcase>    
    {
        public ProductPurchcase CreateModel(IDataReader src)  
        {
            ProductPurchcase productPurchase = new ProductPurchcase()  
            {
                PurchaseId = Convert.ToInt16(src["PurchaseId"]),
                ProductId = Convert.ToInt16(src["ProductId"]),
                Price = Convert.ToInt16(src["Price"]),
                Amount = Convert.ToInt16(src["Amount"]),
            };
            return productPurchase;
        }
    }
}
