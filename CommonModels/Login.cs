using System.ComponentModel.DataAnnotations;

namespace CommonModels
{
    public class Login
    {
        [Required]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "email requires: @,.com,.co")]
        public string emailId { get; set; }
        [Required]
       // [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "Minimum eight characters, at least one uppercase letter, one lowercase letter, one number and one special character:")]
        public string password { get; set; }

    }
}