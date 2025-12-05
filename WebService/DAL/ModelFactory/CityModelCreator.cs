using Models;
using System.Data;

namespace WebService.DAL.ModelFactory
{
    public class CityModelCreator : IModelCreator<Models.City>
    {
        public City CreateModel(IDataReader src)
        {
            City city = new City();
            {
                city.CityId = (int)src["CityId"];
                city.CityName = src["CityName"] as string;
                
            };
            return city;
        }
    }
}
