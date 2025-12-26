using Models;
using System.Data;

namespace WebService.DAL
{
    public class OrderStatusCreator : IModelCreator<OrderStatus>
    {
        public OrderStatus CreateModel(IDataReader src)
        {
            OrderStatus orderStatus = new OrderStatus()
            {
                StatusId = Convert.ToInt16(src["OrderStatusId"]),
                StatusName = Convert.ToString(src["StatusName"]),
            };
            return orderStatus;
        }   
    
    }
}
