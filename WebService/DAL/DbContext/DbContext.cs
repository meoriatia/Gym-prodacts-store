using System.Data;
using System.Data.OleDb;

namespace WebService
{
    public class DbContext : IDbContext
    {
        // משתנים לשימוש בפעולות החיבור למסד הנתונים
        OleDbCommand command; // להכנת והפעלת פקודות SQL
        OleDbConnection connection; // לניהול חיבור למסד הנתונים
        OleDbTransaction transaction; // לניהול טרנזקציות (כדי לנהל Commit ו-RollBack)

        static DbContext? dbContext;

        // יצירת Singleton כדי להבטיח שיש רק מופע אחד של DbContext
        public static DbContext GetInstance()
        {
            if (dbContext == null)
                dbContext = new DbContext();
            return dbContext;
        }

        // בנאי פרטי (פרטי כדי למנוע יצירת מופעים נוספים מחוץ למחלקה)
        private DbContext()
        {
            // הגדרת נתיב החיבור למסד הנתונים
            connection = new OleDbConnection
            {
                ConnectionString = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={Directory.GetCurrentDirectory()}/App_Data/Database.accdb"
            };

            // יצירת אובייקט הפקודה (command) לחיבור למסד הנתונים
            command = new OleDbCommand();
            command = connection.CreateCommand();

            //transaction = connection.BeginTransaction();
        }

        // סגירת החיבור וניקוי טרנזקציות
        public void CloseConnection()
        {
            connection.Close();
            if (transaction != null)
                transaction.Dispose();
            ClearParameters();
        }

        // אישור הטרנזקציה הנוכחית (התחייבות על השינויים במסד הנתונים)
        public void Commit()
        {
            transaction.Commit();
        }

        // מחיקה במסד הנתונים לפי שאילתה שנשלחה
        public bool Delete(string sql)
        {
            return ChangeDb(sql);
        }

        // הוספת רשומה חדשה במסד הנתונים לפי השאילתה
        public bool Insert(string sql)
        {
            return ChangeDb(sql);
        }

        // פתיחת חיבור למסד הנתונים
        public void OpenConnection()
        {
            connection.Open();
        }

        // שליפת רשומות לפי השאילתה שמתקבלת
        public IDataReader Read(string sql)
        {
            command.CommandText = sql;
            IDataReader reader = command.ExecuteReader();
            ClearParameters();
            return reader;
        }

        // ביטול השינויים בטרנזקציה הנוכחית (שחזור למצב קודם)
        public void RollBack()
        {
            this.transaction.Rollback();
        }

        // עדכון במסד הנתונים לפי השאילתה
        public bool Update(string sql)
        {
            return ChangeDb(sql);
        }

        // פונקציה פרטית שמבצעת שינויים במסד הנתונים (מחיקה, הוספה, עדכון)
        private bool ChangeDb(string sql)
        {
            command.CommandText = sql;
            bool ok = command.ExecuteNonQuery() > 0; // מחזירה true אם העדכון הצליח, אחרת false
            ClearParameters();
            return ok;
        }
        public void AddParameter(string paramName, string value)
        {
            this.command.Parameters.Add(new OleDbParameter(paramName, value));
        }
        public void ClearParameters() 
        { 
            this.command.Parameters.Clear();
        }
    }
}
