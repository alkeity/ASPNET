using System.ComponentModel.DataAnnotations;

namespace Homework7_WebAPI.Models
{
    public class UserData
    {
        [Key]
        public required string Key { get; set; }
        public required string Value { get; set; }

    }
}
