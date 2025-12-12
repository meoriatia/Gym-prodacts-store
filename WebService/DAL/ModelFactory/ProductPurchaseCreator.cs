using Models;
using System.Data;

namespace WebService.DAL.ModelFactory
{
    public class ProductPurchaseCreator : IModelCreator<ProductPurchase>    
    {
        public ProductPurchase CreateModel(IDataReader src)  
        {
            ProductPurchase productPurchase = new ProductPurchase()  
            {
                PurchaseId = Convert.ToInt16(src["ProductPurchaseId"]),
                ProductId = Convert.ToInt16(src["ProductId"]),
                Price = Convert.ToInt16(src["PurchaseId"]),
                Amount = Convert.ToInt16(src["Quantity"]),
            };
            return productPurchase;
        }
    }
}
