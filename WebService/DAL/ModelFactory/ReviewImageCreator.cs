using Models;
using System.Data;

namespace WebService.DAL.ModelFactory
{
    public class ReviewImageCreator : IModelCreator<ReviewImage>    
    {
        public ReviewImage CreateModel(IDataReader src)
        {
            ReviewImage reviewImage = new ReviewImage()
            {
                ReviewImageId = Convert.ToInt16(src["ReviewImageId"]),
                ReviewId = Convert.ToInt16(src["ReviewId"]),
                ImageName = Convert.ToString(src["ImageName"]),
                Description = Convert.ToString(src["Description"]),
            };
            return reviewImage;
        }
    }
}
