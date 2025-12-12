using System.Data;
using System.Data.Common;
using Models;

namespace WebService.DAL.Repository
{
    public class CityRepository : Repository, IRepository<City> 
    {
        public CityRepository(DbContext dbContext) : base(dbContext)  { }

        public bool Delete(int id)
        {
            
        }
    }
}
