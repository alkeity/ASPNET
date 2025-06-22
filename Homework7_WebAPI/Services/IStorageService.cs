namespace Homework7_WebAPI.Services
{
    public interface IStorageService
    {
        string? GetValue(string key);
        void SetValue(string key, string value);
    }
}
