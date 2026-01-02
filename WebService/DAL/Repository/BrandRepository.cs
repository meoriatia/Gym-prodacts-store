using System.Data;
using System.Data.Common;
using Models;

namespace WebService.DAL.Repository
{
    public class BrandRepository : Repository, IRepository<Brand>
    {
        public BrandRepository(DbContext dbContext) : base(dbContext) { }

        public bool Delete(int BrandId)
        {
            string sql = $"DELETE FROM Brands WHERE BrandId=@BrandId";
            this.AddParameters("BrandId", BrandId.ToString());
            return this.dbContext.Update(sql);
        }

        public bool Delete(Brand model)
        {
            return Delete(model.BrandId);
        }

        public bool Insert(Brand model)
        {
            string sql = $"INSERT INTO Brands(BrandName,BrandIcon) values(@BrandName,@BrandIcon)";
            this.AddParameters("BrandName", model.BrandName);
            this.AddParameters("BrandIcon", model.BrandIcon);
            return this.dbContext.Update(sql);

        }

        public Brand Read(object BrandId)
        {
            string sql = "SELECT * FROM Brands WHERE BrandId = @BrandId;";
            using IDataReader dataReader = this.dbContext.Read(sql);
            return this.modelFactory.BrandCreator.CreateModel(dataReader);
        }

        public List<Brand> ReadAll()
        {
            List<Brand> values = new List<Brand>();
            string sql = "SELECT * FROM Brands;";
            using (IDataReader dataReader = this.dbContext.Read(sql))
            {
                while (dataReader.Read())
                {
                    values.Add(this.modelFactory.BrandCreator.CreateModel(dataReader));
                }
                return values;
            }
        }

        public bool Update(Brand model)
        {
            string sql = "UPDATE Brands SET BrandName=@BrandName, BrandIcon=@BrandIcon WHERE BrandId=@BrandId";
            this.AddParameters("BrandId", model.BrandId.ToString());
            this.AddParameters("BrandName", model.BrandName);
            this.AddParameters("BrandIcon", model.BrandIcon);
            return this.dbContext.Update(sql);
        }
    }
}
