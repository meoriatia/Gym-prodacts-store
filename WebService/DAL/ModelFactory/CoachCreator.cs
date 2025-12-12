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
                CoachSecurityNum = Convert.ToInt16(src["CoachSecurityNum"]),
                CoachFirstName = Convert.ToString(src["CoachFirstName"]),
                CoachPicture = Convert.ToString(src["CoachPicture"]),
                CoachLastName = Convert.ToString(src["CoachLastName"]),
            };  
            return coach;
        }
    }
}