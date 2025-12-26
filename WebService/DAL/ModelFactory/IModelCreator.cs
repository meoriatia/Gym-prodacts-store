using System.Data;

namespace WebService.DAL  // מגדיר מרחב שם
{
    public interface IModelCreator<T>  // ממשק שמגדיר פונקציה ליצירת מודל מסוג T
    {
        T CreateModel(IDataReader src);  // פונקציה שיוצרת אובייקט מסוג T מתוך IDataReader
    }
}
