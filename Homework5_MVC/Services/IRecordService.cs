using Homework5_MVC.Models;

namespace Homework5_MVC.Services
{
    public interface IRecordService
    {
        public void RecordItems(List<Review> items);

        public List<Review> GetAllItems();
    }
}
