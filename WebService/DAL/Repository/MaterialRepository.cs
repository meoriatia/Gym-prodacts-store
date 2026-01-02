using System.Data;
using System.Data.Common;
using Models;

namespace WebService.DAL.Repository
{
    public class MaterialRepository : Repository, IRepository<Material>
    {
        public MaterialRepository(DbContext dbContext) : base(dbContext) { }

        public bool Delete(int MaterialId)
        {
            string sql = $"DELETE FROM Materials WHERE MaterialId=@MaterialId";
            this.AddParameters("MaterialId", MaterialId.ToString());
            return this.dbContext.Update(sql);
        }

        public bool Delete(Material model)
        {
            return Delete(model.MaterialId);
        }

        public bool Insert(Material model)
        {
            string sql = $"INSERT INTO City(MaterialName,MaterialDescription) values(@CityName,@MaterialDescription)";
            this.AddParameters("MaterialName", model.MaterialName);
            this.AddParameters("MaterialDescription", model.MaterialDescription);
            return this.dbContext.Update(sql);

        }

        public Material Read(object MaterialId)
        {
            string sql = "SELECT * FROM Materials WHERE MaterialId = @MaterialId;";
            using IDataReader dataReader = this.dbContext.Read(sql);
            return this.modelFactory.MaterialCreator.CreateModel(dataReader);
        }

        public List<Material> ReadAll()
        {
            List<Material> values = new List<Material>();
            string sql = "SELECT  * FROM Materials;";
            using (IDataReader dataReader = this.dbContext.Read(sql))
            {
                while (dataReader.Read())
                {
                    values.Add(this.modelFactory.MaterialCreator.CreateModel(dataReader));
                }
                return values;
            }
        }

        public bool Update(Material model)
        {
            string sql = "UPDATE Materials SET MaterialName=@MaterialName,MaterialDescription=@MaterialDescription WHERE MaterialId=@MaterialId";
            this.AddParameters("MaterialId", model.MaterialId.ToString());
            this.AddParameters("MaterialName", model.MaterialName);
            this.AddParameters("Materialdescription", model.MaterialDescription);
            return this.dbContext.Update(sql);
        }
    }
}

