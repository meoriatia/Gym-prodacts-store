using Models;
using System.Data;

namespace WebService.DAL
{
    public class BrandCreator : IModelCreator<Brand>
    {
        public Brand CreateModel(IDataReader src)
        {
            Brand brand = new Brand()
            {
                BrandId = Convert.ToInt16(src["BrandId"]),
                BrandName = Convert.ToString(src["BrandName"]),
                BrandIcon = Convert.ToString(src["BrandIcon"]),
            };
            return brand;
        }
    }
}
