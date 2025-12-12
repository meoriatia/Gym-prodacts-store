using System.Data;
using System.Data.Common;
using Models;

namespace WebService.DAL.Repository
{
    public class ProductTypeRepository : Repository, IRepository<ProductType>
    {
        public ProductTypeRepository(DbContext dbContext) : base(dbContext) { }

        public bool Delete(int ProductTypeId)
        {
            string sql = $"DELETE FROM ProductType WHERE ProductTypeId=@ProductTypeId";
            this.AddParameters("ProductTypeId", ProductTypeId.ToString());
            return this.dbContext.Update(sql);
        }

        public bool Delete(ProductType model)
        {
            return Delete(model.ProductTypeId);
        }

        public bool Insert(ProductType model)
        {
            string sql = $"INSERT INTO ProductType(ProductTypeName) values(@ProductTypeName)";
            this.AddParameters("ProductTypeName", model.ProductTypeName);
            return this.dbContext.Update(sql);

        }

        public ProductType Read(object ProductTypeId)
        {
            string sql = "SELECT ProductType.* FROM ProductType WHERE ProductTypeId = @ProductTypeId;";
            using IDataReader dataReader = this.dbContext.Read(sql);
            return this.modelFactory.ProductTypeCreator.CreateModel(dataReader);
        }

        public List<ProductType> ReadAll()
        {
            List<ProductType> values = new List<ProductType>();
            string sql = "SELECT ProductType.* FROM ProductType;";
            using (IDataReader dataReader = this.dbContext.Read(sql))
            {
                while (dataReader.Read())
                {
                    values.Add(this.modelFactory.ProductTypeCreator.CreateModel(dataReader));
                }
                return values;
            }
        }

        public bool Update(ProductType model)
        {
            string sql = $"UPDATE Purchase SET UserId=@UserId,ProductId=@ProductId,ReciptNumber=@ReciptNumber,PurchaseDate=@PurchaseDate,PurchaseId=@PurchaseId,ProductPrice=@ProductPrice WHERE ProductId=@ProductId";
            this.AddParameters("ProductId", model.ProductId.ToString());
            this.AddParameters("UserId,ProductId,ReciptNumber,PurchaseDate,PurchaseId,ProductPrice", model.UserId, ProductId, ReciptNumber, PurchaseDate, PurchaseId, ProductPrice);
            return this.dbContext.Update(sql);
        }
    }
}