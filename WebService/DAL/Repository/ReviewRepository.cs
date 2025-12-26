using System.Data;
using System.Data.Common;
using Models;

namespace WebService.DAL.Repository
{
    public class ReviewRepository : Repository, IRepository<Review>
    {
        public ReviewRepository(DbContext dbContext) : base(dbContext) { }

        public bool Delete(int ReviewId)
        {
            string sql = $"DELETE FROM Review WHERE ReviewId=@ReviewId";
            this.AddParameters("ReviewId", ReviewId.ToString());
            return this.dbContext.Update(sql);
        }

        public bool Delete(Review model)
        {
            return Delete(model.ReviewId);
        }

        public bool Insert(Review model)
        {
            string sql = $"INSERT INTO Review(UserId,Title,Description,Rating) values(@UserId,@Title,@Description,@Rating)";
            this.AddParameters("UserId", model.UserId.ToString());
            this.AddParameters("Title", model.Title);
            this.AddParameters("Description", model.Description);
            this.AddParameters("Rating", model.Rating.ToString());
            return this.dbContext.Update(sql);

        }

        public Review Read(object ReviewId)
        {
            string sql = "SELECT Review.* FROM Review WHERE ReviewId = @ReviewId;";
            using IDataReader dataReader = this.dbContext.Read(sql);
            return this.modelFactory.ReviewCreator.CreateModel(dataReader);
        }

        public List<Review> ReadAll()
        {
            List<Review> values = new List<Review>();
            string sql = "SELECT Review.* FROM Review;";
            using (IDataReader dataReader = this.dbContext.Read(sql))
            {
                while (dataReader.Read())
                {
                    values.Add(this.modelFactory.ReviewCreator.CreateModel(dataReader));
                }
                return values;
            }
        }

        public bool Update(Review model)
        {
            string sql = $"UPDATE Review SET UserId=@UserId,Title=@Title,Description=@Description,Rating=@Rating WHERE ReviewId=@ReviewId";
            this.AddParameters("ReviewId", model.ReviewId.ToString());
            this.AddParameters("UserId", model.UserId.ToString());
            this.AddParameters("Title", model.Title);
            this.AddParameters("Description", model.Description);
            this.AddParameters("Rating", model.Rating.ToString());
            return this.dbContext.Update(sql);
        }
    }
}
