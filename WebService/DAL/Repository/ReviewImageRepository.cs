using System.Data;
using System.Data.Common;
using Models;

namespace WebService.DAL.Repository
{
    public class ReviewImageRepository : Repository, IRepository<ReviewImage>
    {
        public ReviewImageRepository(DbContext dbContext) : base(dbContext) { }

        public bool Delete(int ReviewImageId)
        {
            string sql = $"DELETE FROM ReviewImage WHERE ReviewImageId=@ReviewImageId";
            this.AddParameters("ReviewImageId", ReviewImageId.ToString());
            return this.dbContext.Update(sql);
        }

        public bool Delete(ReviewImage model)
        {
            return Delete(model.ReviewImageId);
        }

        public bool Insert(ReviewImage model)
        {
            string sql = $"INSERT INTO ReviewImage(ReviewId,ImageName,Description) values(@ReviewId,@ImageName,@Description)";
            this.AddParameters("ReviewId", model.ReviewId.ToString());
            this.AddParameters("ImageName", model.ImageName);
            this.AddParameters("Description", model.Description);
            return this.dbContext.Update(sql);

        }

        public ReviewImage Read(object ReviewImageId)
        {
            string sql = "SELECT ReviewImage.* FROM ReviewImage WHERE ReviewImageId = @ReviewImageId;";
            using IDataReader dataReader = this.dbContext.Read(sql);
            return this.modelFactory.ReviewImageCreator.CreateModel(dataReader);
        }

        public List<ReviewImage> ReadAll()
        {
            List<ReviewImage> values = new List<ReviewImage>();
            string sql = "SELECT ReviewImage.* FROM ReviewImage;";
            using (IDataReader dataReader = this.dbContext.Read(sql))
            {
                while (dataReader.Read())
                {
                    values.Add(this.modelFactory.ReviewImageCreator.CreateModel(dataReader));
                }
                return values;
            }
        }

        public bool Update(ReviewImage model)
        {
            string sql = $"UPDATE ReviewImage SET ReviewId=@ReviewId, ImageName=@ImageName, Description=@Description WHERE ReviewImageId=@ReviewImageId";
            this.AddParameters("ReviewImageId", model.ReviewImageId.ToString());
            this.AddParameters("ReviewId", model.ReviewId.ToString());
            this.AddParameters("ImageName", model.ImageName);
            this.AddParameters("Description", model.Description);
            return this.dbContext.Update(sql);
        }
    }
}