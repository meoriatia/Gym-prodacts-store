using System.Data;  // מייבא עבודה עם נתונים (IDataReader)

namespace WebService  // מגדיר מרחב שם
{
    public interface IModelCreator<T>  // ממשק שמגדיר פונקציה ליצירת מודל מסוג T
    {
        T CreateModel(IDataReader src);  // פונקציה שיוצרת אובייקט מסוג T מתוך IDataReader
    }
}
