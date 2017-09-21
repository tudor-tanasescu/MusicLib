using System.ComponentModel.DataAnnotations;

namespace MusicLibrary.Web.Models.Identity
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Display name:")]
        public string Alias { get; set; }

        [Required]
        [Display(Name = "User name:")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password:")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password:")]
        [Compare(nameof(Password), ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email:")]
        public string Email { get; set; }

        [Display(Name = "Recieve email notifications")]
        public bool RecievesEmailNotifications { get; set; } = true;

    }
}