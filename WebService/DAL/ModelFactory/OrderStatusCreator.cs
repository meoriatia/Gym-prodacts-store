using Models;
using System.Data;

namespace WebService.DAL.ModelFactory
{
    public class OrderStatusCreator : IModelCreator<Status>
    {
        public OrderStatus CreateModel(IDataReader src)
        {
            OrderStatus ordeostatus = new OrderStatus()
            {
                OrderStatusId = Convert.ToInt16(src["OrderStatusId"]),
                StatusName = Convert.ToString(src["StatusName"]),
            };
            return orderStatus;
        }   
    
    }
}
