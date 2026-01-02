using System.Data.OleDb;
using WebService.DAL;

namespace WebService.DAL.Repository
{
    public class Repository
    {
        protected DbContext dbContext;
        protected ModelFactory modelFactory;

        public Repository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.modelFactory = new ModelFactory();
        }

        protected void AddParameters(string paramName, object paramValue)
        {
            this.dbContext.AddParameter(paramName, paramValue);
        }
    }
}
