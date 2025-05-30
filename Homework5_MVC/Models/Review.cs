using Homework5_MVC.Services;

namespace Homework5_MVC.Models
{
    public class Review
    {
        public int Id { get; set; }
        public DateTime ReviewDate { get; set; }
        public required string UserName { get; set; }
        public required string Text { get; set; }

        private byte _rating;
        public required byte Rating
        {
            get => _rating;
            set
            {
                if (value < 1 || value > 10) throw new ArgumentOutOfRangeException("Rating must be between 1 and 10");
                _rating = value;
            }
        }
    }

    public class ReviewPage
    {
        public required List<Review> Reviews { get; set; }

        public Review NewReview { get; set; }

        public ReviewPage()
        {
            NewReview = new Review() { UserName = "Anonymous", Rating = 5, Text = "" };
        }

    }
}
