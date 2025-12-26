using Models;
using System.Data;

namespace WebService.DAL
{
    public class PurchaseCreator : IModelCreator<Purchase>

    {
        public Purchase CreateModel(IDataReader src)
        {
            Purchase purchase = new Purchase()
            {
                PurchaseId = Convert.ToInt16(src["PurchaseId"]),
                UserId = Convert.ToInt16(src["UserId"]),
                PurchaseDate = Convert.ToDateTime(src["PurchaseDate"]),
                StatusId = Convert.ToInt16(src["StatusId"]),
            };
            return purchase;
        }
    }
}
