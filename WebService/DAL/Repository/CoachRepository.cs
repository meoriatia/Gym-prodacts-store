using System.Data;
using System.Data.Common;
using Models;

namespace WebService.DAL.Repository
{
    public class CoachRepository : Repository , IRepository<coach>
    {
        public CityRepository(DbContext dbContext) : base(dbContext) { }

        public bool Delete(int CoachId)
        {
            string sql = $"DELETE FROM Coach WHERE CoachId=@CoachId";
            this.AddParameters("CoachId", CoachId.ToString());
            return this.dbContext.Update(sql);
        }

        public bool Delete(City model)
        {
            return Delete(model.CityId);
        }


        public bool Insert(Coach model)
        {
            string sql = $"INSERT INTO Coach(CoachSecurityNum,CoachFirstName,CoachPicture,CoachLastName) values(@CoachSecurityNumber,@CoachFirstName,@CoachPicture,@coachLastName)";
            this.AddParameters("CoachSecurityNum,CoachFirstName,CoachPicture,CoachLastName", model.CoachSecurityNum, CoachFirstName, CoachPicture, CoachLastName);
            return this.dbContext.Update(sql);

        }


        public Coach Read(object CoachId)
        {
            string sql = "SELECT coach.* FROM coach WHERE coachId = @coachId;";
            using IDataReader dataReader = this.dbContext.Read(sql);
            return this.modelFactory.CoachCreator.CreateModel(dataReader);
        }

        public List<Coach> ReadAll()
        {
            List<Coach> values = new List<Coach>();
            string sql = "SELECT coach.* FROM coach;";
            using (IDataReader dataReader = this.dbContext.Read(sql))
            {
                while (dataReader.Read())
                {
                    values.Add(this.modelFactory.CoachCreator.CreateModel(dataReader));
                }
                return values;
            }
        }

        public bool Update(Coach model)
        {
            string sql = "UPDATE Coach SET CoachFirstName=@CoachFirstName,CoachSecurityNumber=@CoachSecurityNumber,CoachLastName=@CoachLastName WHERE Coach Id=@CoachId";
            this.AddParameters("CoachId", model.Id.ToString());
            this.AddParameters("CoachSecurityNum, CoachFirstName, CoachPicture, CoachLastName", model.CoachSecurityNum, CoachFirstName, CoachPicture, CoachLastName);
            return this.dbContext.Update(sql);
        }
    }
}
