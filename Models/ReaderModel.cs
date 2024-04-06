using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class ReaderModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Birth Date is required")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        public List<BorrowingModel> BorrowedBooks { get; set; } = new List<BorrowingModel>();
    }
}
