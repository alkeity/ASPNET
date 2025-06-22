using Homework7_WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Homework7_WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StorageController : ControllerBase
    {
        private readonly IStorageService _storageService;

        public StorageController(IStorageService storageService)
        {
            _storageService = storageService;
        }

        [HttpGet]
        [Route("{key}")]
        public string? GetValueByKey(string key)
        {
            return _storageService.GetValue(key);
        }

        [HttpPut]
        [Route("{key}")]
        public IActionResult PutValueByKey(string key, [FromForm] string value)
        {
            _storageService.SetValue(key, value);
            return Ok();
        }
    }
}
