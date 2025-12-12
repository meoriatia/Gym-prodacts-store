using Models;
using System.Data;

namespace WebService.DAL.ModelFactory
{
    public class ReviewCreator : IModelCreator<Review>
    {
        public Review CreateModel(IDataReader src)
        {
            Review review = new Review()
            {
                ReviewId = Convert.ToInt16(src["ReviewId"]),
                Description = Convert.ToString(src["ProductId"]),
                UserId = Convert.ToInt16(src["UserId"]),
                Rating = Convert.ToInt16(src["Rating"]),
                Comment = Convert.ToString(src["Comment"]),
                Title = Convert.ToString(src["ReviewDate"]),
            };
            return review;
        }
    }   
}

