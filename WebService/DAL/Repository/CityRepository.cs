using System.Data;
using System.Data.Common;
using Models;

namespace WebService.DAL.Repository
{
    public class CityRepository : Repository, IRepository <city>
    {
        public CityRepository(DbContext dbContext) : base(dbContext) { }

        public bool Delete(int CityId)
        {
            string sql = $"DELETE FROM City WHERE CityId=@CityId";
            this.AddParameters("CityId", CityId.ToString()); 
            return this.dbContext.Update(sql);
        }

        public bool Delete(City model)
        {
            return Delete(model.CityId);
        }

        public bool Insert(City model)
        {
            string sql = $"INSERT INTO City(CityName) values(@CityName)";
            this.AddParameters("CityName", model.CityName); 
            return this.dbContext.Update(sql);

        }

        public City Read(object CityId)
        {
            string sql = "SELECT city.* FROM city WHERE CityId = @CityId;";
            using IDataReader dataReader = this.dbContext.Read(sql);
            return this.modelFactory.CityCreator.CreateModel(dataReader);
        }

        public List<City> ReadAll()
        {
            List<City> values = new List<City>();
            string sql = "SELECT city.* FROM city;";
            using (IDataReader dataReader = this.dbContext.Read(sql))
            {
                while (dataReader.Read())
                {
                    values.Add(this.modelFactory.CityCreator.CreateModel(dataReader));
                }
                return values;
            }
        }

        public bool Update(City model)
        {
            string sql = "UPDATE City SET CityName=@CityName WHERE CityId=@CityId";
            this.AddParameters("CityId", model.CityId.ToString()); 
            this.AddParameters("CityName", model.CityName); 
            return this.dbContext.Update(sql);
        }
    }
}
