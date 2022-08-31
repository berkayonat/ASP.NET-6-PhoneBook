using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PhoneBook.Models.ViewModels
{
    public class PersonViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The name is required")]
        public string? Name { get; set; }
        [Required]
        [DisplayName("Phone Number")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "The phone number is not valid")]
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
    }
}
