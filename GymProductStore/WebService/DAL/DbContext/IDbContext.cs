using System.Data;

namespace WebService
{
    // ממשק לניהול תקשורת עם מסד נתונים
    public interface IDbContext
    {
        // פתיחת חיבור למסד הנתונים
        void OpenConnection();

        // סגירת חיבור למסד הנתונים
        void CloseConnection();

        // קריאת נתונים מרובים ממסד הנתונים לפי שאילתת SQL ומחזיר אובייקט IDataReader
        IDataReader Read(string sql);

        // עדכון נתונים במסד הנתונים לפי שאילתת SQL
        bool Update(string sql);

        // הוספת נתונים למסד הנתונים לפי שאילתת SQL
        bool Insert(string sql);

        // מחיקת נתונים ממסד הנתונים לפי שאילתת SQL
        bool Delete(string sql);

        // התחייבות על הפעולות במסד הנתונים (שומר את השינויים)
        void Commit();

        // ביטול פעולות במצב טרנזקציה אחרון (מחזיר את מסד הנתונים למצב הקודם)
        void RollBack();
    }
}
