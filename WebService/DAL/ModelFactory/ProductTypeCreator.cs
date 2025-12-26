using Models;
using System.Data;

namespace WebService.DAL
{
    public class ProductTypeCreator : IModelCreator<ProductType>
    {
        public ProductType CreateModel(IDataReader src)
        {
            ProductType productType = new ProductType()
            {
                ProductTypeId = Convert.ToInt16(src["ProductTypeId"]),
                ProductTypeName = Convert.ToString(src["ProductTypeName"]),
            };
            return productType;
        }   
    }
}
