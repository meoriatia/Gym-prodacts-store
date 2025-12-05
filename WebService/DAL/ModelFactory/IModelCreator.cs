using System.Data;

namespace WebService.DAL.ModelFactory  // מגדיר מרחב שם
{
    public interface IModelCreator<T>  // ממשק שמגדיר פונקציה ליצירת מודל מסוג T
    {
        T CreateModel(IDataReader src);  // פונקציה שיוצרת אובייקט מסוג T מתוך IDataReader
    }
}
