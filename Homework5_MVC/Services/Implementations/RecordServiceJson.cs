using System.Text.Json;
using Homework5_MVC.Models;

namespace Homework5_MVC.Services.Implementations
{
    public class RecordServiceJson : IRecordService
    {
        private string filePath = "reviews.json";

        public List<Review> GetAllItems()
        {
            if (File.Exists(filePath))
            {
                string itemsStr = File.ReadAllText(filePath);
                List<Review> items = JsonSerializer.Deserialize<List<Review>>(itemsStr);
                return items != null ? items : new List<Review>();
            }
            return new List<Review>();
        }

        public void RecordItems(List<Review> items)
        {
            string tasksStr = JsonSerializer.Serialize(items, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, tasksStr);
        }
    }
}
