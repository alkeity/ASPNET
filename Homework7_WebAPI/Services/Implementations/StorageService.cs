using Homework7_WebAPI.Data;
using Homework7_WebAPI.Models;

namespace Homework7_WebAPI.Services.Implementations
{
    public class StorageService : IStorageService
    {
        private readonly AppDbContext _db;

        public StorageService(AppDbContext db)
        {
            _db = db;
        }
        public string? GetValue(string key)
        {
            UserData data = _db.Storage.Where(userData => userData.Key == key).FirstOrDefault();

            return data == null ? null : data.Value;
        }

        public void SetValue(string key, string value)
        {
            UserData data = new UserData { Key = key, Value = value };
            _db.Storage.Add(data);
            _db.SaveChanges();
        }
    }
}
