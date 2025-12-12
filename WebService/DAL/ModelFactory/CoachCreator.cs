using Models;
using System.Data;

namespace WebService.DAL.ModelFactory
{
    public class CoachCreator : IModelCreator<Coach>
    {
        public Coach CreateModel(IDataReader src)
        {
            Coach coach = new Coach()
            {
                CoachId = Convert.ToInt16(src["CoachId"]),
                CoachSecurityNumber = Convert.ToInt16(src["CoachSecurityNumber"]),
                CoachFirstName = Convert.ToString(src["CoachFirstName"]),
                CoachPicture = Convert.ToString(src["CoachPicture"]),
                CoachLastName = Convert.ToString(src["CoachLastName"]),
            };  
            return coach;
        }
    }
}