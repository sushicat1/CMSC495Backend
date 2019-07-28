using System.ComponentModel.DataAnnotations;

namespace CMSC495Backend.Models
{
    public class Users
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string UserName { get; set; }
    }
}