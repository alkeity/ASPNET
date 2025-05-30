using Homework5_MVC.Models;

namespace Homework5_MVC.Services
{
    public interface IReviewService
    {
        public List<Review> GetLastReviews(int amount);

        public void AddReview(Review review);
    }
}
