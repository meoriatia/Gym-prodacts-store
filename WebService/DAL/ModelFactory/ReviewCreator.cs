using Models;
using System.Data;

namespace WebService.DAL
{
    public class ReviewCreator : IModelCreator<Review>
    {
        public Review CreateModel(IDataReader src)
        {
            Review review = new Review()
            {
                ReviewId = Convert.ToInt16(src["ReviewId"]),
                Description = Convert.ToString(src["Description"]),
                UserId = Convert.ToInt16(src["UserId"]),
                Rating = Convert.ToInt16(src["Rating"]),
                Title = Convert.ToString(src["Title"]),
            };
            return review;
        }
    }   
}

