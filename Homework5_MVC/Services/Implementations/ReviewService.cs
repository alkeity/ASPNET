using Homework5_MVC.Models;

namespace Homework5_MVC.Services.Implementations
{
    public class ReviewService : IReviewService
    {
        IRecordService _recordService;

        public ReviewService(IRecordService recordService)
        {
            _recordService = recordService;
        }
        public void AddReview(Review review)
        {
            List<Review> reviews = _recordService.GetAllItems();
            review.Id = reviews.Count > 0 ? reviews.Max(r => r.Id) + 1 : 0;
            review.ReviewDate = DateTime.Now;
            reviews.Add(review);
            _recordService.RecordItems(reviews);
        }

        public List<Review> GetLastReviews(int amount)
        {
            List<Review> reviews = _recordService.GetAllItems();
            reviews.Sort((review1, review2) => review2.ReviewDate.CompareTo(review1.ReviewDate));
            return reviews.Count > amount ? reviews.GetRange(0, amount) : reviews;
        }
    }
}
