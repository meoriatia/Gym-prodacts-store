using Models;
using System.Data;

namespace WebService.DAL
{
    public class CityCreator : IModelCreator<City>
    {
        public City CreateModel(IDataReader src)
        {
            City city = new City()
            {
                CityId = Convert.ToInt16(src["CityId"]),
                CityName = Convert.ToString(src["CityName"]),              
            };
            return city;
        }
    }
}
