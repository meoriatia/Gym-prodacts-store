using Models;
using System.Data;

namespace WebService.DAL
{
    public class ProductCreator : IModelCreator<Product>
    {
        public Product CreateModel(IDataReader src)
        {
            Product product = new Product()
            {
                ProductId = Convert.ToInt16(src["ProductId"]),
                Price = Convert.ToInt16(src["Price"]),
                ProductName = Convert.ToString(src["ProductName"]),
                Flavored = Convert.ToBoolean(src["Flavored"]),
                ProductTypeId = Convert.ToInt16(src["ProductTypeId"]),
                ProductPhoto = Convert.ToString(src["ProductPhoto"]),
            };
            return product;
        }
    }    
}

