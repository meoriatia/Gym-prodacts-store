using System.Data.OleDb;
using WebService.DAL.ModelCreator;

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

        protected void AddParameters(string paramName, string paramValue)
        {
            this.dbContext.AddParameter(paramName, paramValue);
        }
    }
}
