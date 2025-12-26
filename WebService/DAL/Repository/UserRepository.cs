using System.Data;
using System.Data.Common;
using Models;

namespace WebService.DAL.Repository
{
    public class UserRepository : Repository, IRepository<User>
    {
        public UserRepository(DbContext dbContext) : base(dbContext) { }

        public bool Delete(int UserId)
        {
            string sql = $"DELETE FROM User WHERE UserId=@UserId";
            this.AddParameters("UserId", UserId.ToString());
            return this.dbContext.Update(sql);
        }

        public bool Delete(User model)
        {
            return Delete(model.UserId);
        }

        public bool Insert(User model)
        {
            string sql = $"INSERT INTO User(UserFirstName,UserPassword,CityId,Address,PhoneNum) values(@UserFirstName,@UserPassword,@CityId,@Address,@PhoneNum)";
            this.AddParameters("UserFirstName", model.UserFirstName);
            this.AddParameters("CityId", model.CityId.ToString());
            this.AddParameters("Address", model.Address);
            this.AddParameters("PhoneNum", model.PhoneNum);
            return this.dbContext.Update(sql);

        }

        public User Read(object UserId)
        {
            string sql = "SELECT User.* FROM User WHERE UserId = @UserId;";
            using IDataReader dataReader = this.dbContext.Read(sql);
            return this.modelFactory.UserCreator.CreateModel(dataReader);
        }

        public List<User> ReadAll()
        {
            List<User> values = new List<User>();
            string sql = "SELECT User.* FROM User;";
            using (IDataReader dataReader = this.dbContext.Read(sql))
            {
                while (dataReader.Read())
                {
                    values.Add(this.modelFactory.UserCreator.CreateModel(dataReader));
                }
                return values;
            }
        }

        public bool Update(User model)
        {
            string sql = $"UPDATE User SET UserFirstName=@UserFirstName,UserPassword=@UserPassword,CityId=@CityId,Address=@Address,PhoneNum=@PhoneNum WHERE UserId=@UserId";
            this.AddParameters("UserId", model.UserId.ToString());
            this.AddParameters("UserFirstName", model.UserFirstName);
            this.AddParameters("CityId", model.CityId.ToString());
            this.AddParameters("Address", model.Address);
            this.AddParameters("PhoneNum", model.PhoneNum);
            return this.dbContext.Update(sql);
        }
    }
}
