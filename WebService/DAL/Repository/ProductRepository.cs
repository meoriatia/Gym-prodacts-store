using Models;
using System.Data;
using System.Data.Common;
using System.Diagnostics.Eventing.Reader;
using System.Reflection;

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

        internal List<Product> ReadByRaiting(int usersRaitings, int minPrice, int maxPrice)
        {
            List<Product> values = new List<Product>();
            string sql = "";
            if(usersRaitings == 0 && minPrice == 0 && maxPrice == 0)
            {
               return this.ReadAll();
            }
            else if (usersRaitings!=0 && minPrice==0 && maxPrice==0)
            {
             sql = @"SELECT Product.ProductId, Product.ProductName, Product.ProductTypeId, Product.ProductPhoto, Product.Flavored, Product.ProductPrice, Product.BrandId, Review.Rating
                          FROM Product INNER JOIN Review ON Product.ProductId = Review.ProductId
                          WHERE Review.Rating>@UsersRaitings";
            this.AddParameters("UsersRaitings", usersRaitings);
            }
            else if(usersRaitings != 0 && minPrice != 0 && maxPrice!= 0)
            {
                sql = @"SELECT Product.ProductId, Product.ProductName, Product.ProductTypeId, Product.ProductPhoto, Product.Flavored, Product.ProductPrice, Product.BrandId, Review.Rating
                        FROM Product INNER JOIN Review ON Product.ProductId = Review.ProductId
                        WHERE Product.ProductPrice)>@UsersRaitings AND Review.Rating>@MinPrice";
                this.AddParameters("@UsersRaitings", usersRaitings);
                this.AddParameters("@MinPrice", minPrice);
            }
            else if (usersRaitings != 0 && minPrice != 0 && maxPrice == 0)
            {
                sql = @"SELECT Product.ProductId, Product.ProductName, Product.ProductTypeId, Product.ProductPhoto, Product.Flavored, Product.ProductPrice, Product.BrandId, Review.Rating
                        FROM Product INNER JOIN Review ON Product.ProductId = Review.ProductId
                        WHERE Product.ProductPrice>@ProductPrice AND Review.Rating>@Rating;
 ";
                this.AddParameters("@ProductPrice", minPrice);
                this.AddParameters("@Rating", usersRaitings);
            }
            else if (usersRaitings != 0 && minPrice != 0 && maxPrice != 0)
            {
                sql = @"SELECT Product.ProductId, Product.ProductName, Product.ProductTypeId, Product.ProductPhoto, Product.Flavored, Product.ProductPrice, Product.BrandId, Review.Rating
                        FROM Product INNER JOIN Review ON Product.ProductId = Review.ProductId
                        WHERE Product.ProductPrice>@ProductPrice AND Product.ProductPrice<@MaxProductPrice  AND Review.Rating>@Rating;
 ";
                this.AddParameters("@ProductPrice", minPrice);
                this.AddParameters("@MaxProductPrice", maxPrice);
                this.AddParameters("@Rating", usersRaitings);
            }
            else if (usersRaitings == 0 && minPrice != 0 && maxPrice != 0)
            {
                sql = @"SELECT Product.ProductId, Product.ProductName, Product.ProductTypeId, Product.ProductPhoto, Product.Flavored, Product.ProductPrice, Product.BrandId, Review.Rating
                        FROM Product INNER JOIN Review ON Product.ProductId = Review.ProductId
                        WHERE Product.ProductPrice>@ProductPrice AND Product.ProductPrice<@MaxProductPrice;
 ";
                this.AddParameters("@ProductPrice", minPrice);
                this.AddParameters("@MaxProductPrice", maxPrice);
            }
            else if (usersRaitings == 0 && minPrice == 0 && maxPrice != 0)
            {
                sql = @"SELECT Product.ProductId, Product.ProductName, Product.ProductTypeId, Product.ProductPhoto, Product.Flavored, Product.ProductPrice, Product.BrandId, Review.Rating
                        FROM Product INNER JOIN Review ON Product.ProductId = Review.ProductId
                        WHERE  Product.ProductPrice<@MaxProductPrice";
                this.AddParameters("@MaxProductPrice", maxPrice);
            }

            using (IDataReader dataReader = this.dbContext.Read(sql))
                {
                    while (dataReader.Read())
                    {
                        values.Add(this.modelFactory.ProductCreator.CreateModel(dataReader));
                    }
                    return values;
                }

        }

        internal List<Product> ReadByRaitingAndPrice(int usersRaitings, int minPrice, int maxPrice)
        {
            List<Product> values = new List<Product>();
            string sql = @"SELECT Product.ProductId, Product.ProductName,
                                  Product.ProductTypeId, Product.ProductPhoto,
                                  Product.Flavored, Product.ProductPrice, Product.BrandId, Review.Rating
                          FROM Product INNER JOIN Review ON Product.ProductId = Review.ProductId
                          WHERE Review.Rating>@UsersRaitings";
            this.AddParameters("UsersRaitings", usersRaitings);
            using (IDataReader dataReader = this.dbContext.Read(sql))
            {
                while (dataReader.Read())
                {
                    values.Add(this.modelFactory.ProductCreator.CreateModel(dataReader));
                }
                return values;
            }
        }
    }
}
