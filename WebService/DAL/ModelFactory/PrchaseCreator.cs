using Models;
using System.Data;

namespace WebService.DAL.ModelFactory
{
    public class PrchaseCreator : IModelCreator<Purchase>

    {
        public Purchase CreateModel(IDataReader src)
        {
            Purchase purchase = new Purchase()
            {
                PurchaseId = Convert.ToInt16(src["PurchaseId"]),
                UserId = Convert.ToInt16(src["UserId"]),
                ProductId = Convert.ToInt16(src["ProductId"]),
                ReciptNumber = Convert.ToInt16(src["Quantity"]),
                PurchaseDate = Convert.ToDateTime(src["PurchaseDate"]),
                StatusId = Convert.ToInt16(src["StatusId"]),
            };
            return purchase;
        }
    }
}
