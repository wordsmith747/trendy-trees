using System.ComponentModel.DataAnnotations;

namespace TrendyTrees.Models
{
    public class ContactViewModel
    {
        [Display(Name = "Full name")]
        [Required(ErrorMessage = "This field is mandatory")]
        public string Name { get; set; }

        [Display(Name = "Email address")]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Display(Name = "Confirm email address")]
        [Compare("EmailAddress")]
        public string ConfirmEmailAddress { get; set; }

        [Display(Name = "Phone number")]
        [Required(ErrorMessage = "This field is mandatory")]
        [Phone(ErrorMessage = "Please, provide a correct phone number.")]
        public string MobilePhone { get; set; }

        [Display(Name = "Message")]
        [Required(ErrorMessage = "This field is mandatory")]
        public string Message { get; set; }
    }
}