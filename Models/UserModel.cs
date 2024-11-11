using System.ComponentModel.DataAnnotations;

namespace Hangfire_EmailNotification.Models
{
    public class UserModel
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; } = string.Empty;
        [Required]
        public string UserEmail { get; set; } = string.Empty;
        [Required]
        public string UserPassword { get; set; } = string.Empty;
        [Required]
        public long UserMobileNumber { get; set; }
        [Required]
        public bool IsSubscribed { get; set; }

    }
}