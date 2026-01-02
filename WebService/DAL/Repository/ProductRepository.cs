using System.Data;
using System.Data.Common;
using Models;

namespace WebService.DAL.Repository
{
    public class ProductRepository : Repository, IRepository<Product>
    {
        public ProductRepository(DbContext dbContext) : base(dbContext) { }

        public bool Delete(int ProductId)
        {
            string sql = $"DELETE FROM Product WHERE ProductId=@ProductId";
            this.AddParameters("ProductId", ProductId.ToString());
            return this.dbContext.Update(sql);
        }

        public bool Delete(Product model)
        {
            return Delete(model.ProductId);
        }

        public bool Insert(Product model)
        {
            string sql = $"INSERT INTO Product(ProductName,Flavored,ProductTypeId,ProductPhoto,ProductPrice) values(@ProductName,@Flavored,@ProductTypeId,@ProductPhoto,@ProductPrice)";
            this.AddParameters("ProductName", model.ProductName);
            this.AddParameters("Flavored", model.Flavored.ToString());
            this.AddParameters("ProductTypeId", model.ProductTypeId.ToString());
            this.AddParameters("ProductPhoto", model.ProductPhoto);
            this.AddParameters("ProductPrice", model.Price.ToString());
            return this.dbContext.Update(sql);

        }

        public Product Read(object ProductId)
        {
            string sql = "SELECT Product.* FROM Product WHERE ProductId = @ProductId;";
            using IDataReader dataReader = this.dbContext.Read(sql);
            return this.modelFactory.ProductCreator.CreateModel(dataReader);
        }

        public List<Product> ReadAll()
        {
            List<Product> values = new List<Product>();
            string sql = "SELECT * FROM [Product];";
            using (IDataReader dataReader = this.dbContext.Read(sql))
            {
                while (dataReader.Read())
                {
                    values.Add(this.modelFactory.ProductCreator.CreateModel(dataReader));
                }
                return values;
            }
        }

        public bool Update(Product model)
        {
            string sql = $"UPDATE Product SET ProductName=@ProductName,Flavored=@Flavored,ProductTypeId=@ProductTypeId,ProductPhoto=@ProductPhoto,ProductPrice=@ProductPrice WHERE ProductId=@ProductId";
            this.AddParameters("ProductName", model.ProductName);
            this.AddParameters("Flavored", model.Flavored.ToString());
            this.AddParameters("ProductTypeId", model.ProductTypeId.ToString());
            this.AddParameters("ProductPhoto", model.ProductPhoto);
            this.AddParameters("ProductPrice", model.Price.ToString());
            return this.dbContext.Update(sql);
        }
    }
}
