using System.Data;
using System.Data.Common;
using Models;

namespace WebService.DAL.Repository
{
    public class OrderStatusRepository : Repository, IRepository<OrderStatus>
    {
        public OrderStatusRepository(DbContext dbContext) : base(dbContext) { }

        public bool Delete(int OrderStatusId)
        {
            string sql = $"DELETE FROM OrderStatus WHERE OrderStatusId=@OrderStatusId";
            this.AddParameters("OrderStatusId",OrderStatusId.ToString());
            return this.dbContext.Update(sql);
        }

        public bool Delete(OrderStatus model)
        {
            return Delete(model.OrderStatusId);
        }

        public bool Insert(OrderStatus model)
        {
            string sql = $"INSERT INTO OrderStatus(StatusName) values(@StatusName)";
            this.AddParameters("StatusName", model.StatusName);
            return this.dbContext.Update(sql);

        }

        public OrderStatus Read(object OrderStatusId)
        {
            string sql = "SELECT OrderStatus.* FROM OrderStatus WHERE OrderStatusId = @OrderStatusId;";
            using IDataReader dataReader = this.dbContext.Read(sql);
            return this.modelFactory.OrderStatusCreator.CreateModel(dataReader);
        }

        public List<OrderStatus> ReadAll()
        {
            List<OrderStatus> values = new List<OrderStatus>();
            string sql = "SELECT OrderStatus.* FROM OrderStatus;";
            using (IDataReader dataReader = this.dbContext.Read(sql))
            {
                while (dataReader.Read())
                {
                    values.Add(this.modelFactory.OrderStatusCreator.CreateModel(dataReader));
                }
                return values;
            }
        }

        public bool Update(OrderStatus model)
        {
            string sql = $"UPDATE OrderStatus SET StatusName=@StatusName WHERE OrderStatusId=@OrderStatusId";
            this.AddParameters("OrderStatusId", model.OrderStatusId.ToString());
            this.AddParameters("StatusName", model.StatusName);
            return this.dbContext.Update(sql);
        }
    }
}
