using System.Data;
using System.Data.Common;
using Models;

namespace WebService.DAL.Repository
{
    public class PurchaseRepository : Repository, IRepository<Purchase>
    {
        public PurchaseRepository(DbContext dbContext) : base(dbContext) { }

        public bool Delete(int PurchaseId)
        {
            string sql = $"DELETE FROM Purchase WHERE PurchaseId=@PurchaseId";
            this.AddParameters("PurchaseId", PurchaseId.ToString());
            return this.dbContext.Update(sql);
        }

        public bool Delete(Purchase model)
        {
            return Delete(model.PurchaseId);
        }

        public bool Insert(Purchase model)
        {
            string sql = $"INSERT INTO Purchase(UserId,PurchaseDate,StatusId) values(@UserId,@PurchaseDate,@StatusId)";
            this.AddParameters("UserId", model.UserId.ToString());
            this.AddParameters("ReciptNumber", model.PurchaseDate.ToString());
            this.AddParameters("StatusId", model.StatusId.ToString());
            return this.dbContext.Update(sql);

        }

        public Purchase Read(object PurchaseId)
        {
            string sql = "SELECT Purchase.* FROM Purchase WHERE PurchaseId = @PurchaseId;";
            using IDataReader dataReader = this.dbContext.Read(sql);
            return this.modelFactory.PurchaseCreator.CreateModel(dataReader);
        }

        public List<Purchase> ReadAll()
        {
            List<Purchase> values = new List<Purchase>();
            string sql = "SELECT Purchase.* FROM Purchase;";
            using (IDataReader dataReader = this.dbContext.Read(sql))
            {
                while (dataReader.Read())
                {
                    values.Add(this.modelFactory.PurchaseCreator.CreateModel(dataReader));
                }
                return values;
            }
        }

        public bool Update(Purchase model)
        {
            string sql = $"UPDATE Purchase SET UserId=@UserId,ProductId=@ProductId,ReciptNumber=@ReciptNumber,PurchaseDate=@PurchaseDate,StatusId=StatusId WHERE PurchaseId=@PurchaseId";
            this.AddParameters("PurchaseId", model.PurchaseId.ToString());
            this.AddParameters("UserId", model.UserId.ToString());
            this.AddParameters("ReciptNumber", model.PurchaseDate.ToString());
            this.AddParameters("StatusId", model.StatusId.ToString());
            return this.dbContext.Update(sql);
        }
    }
}

