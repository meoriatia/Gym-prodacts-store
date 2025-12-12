using Models;
using System.Data;

namespace WebService.DAL.ModelFactory
{
    public class ProductCreator : IModelCreator<Product>
    {
        public Product CreateModel(IDataReader src)
        {
            Product product = new Product()
            {
                ProductId = Convert.ToInt16(src["ProductId"]),
                ProductName = Convert.ToString(src["ProductName"]),
                Flavored = Convert.ToBoolean(src["Price"]),
                ProductTypeId = Convert.ToInt16(src["StockQuantity"]),
                ProductPhoto = Convert.ToString(src["CategoryId"]),
            };
            return product;
        }
    }    
}

