using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection.PortableExecutable;

namespace LibraryManagementSystem.Models
{
    public class BorrowingModel
    {
        public int Id { get; set; }

      
        [Required(ErrorMessage = "Book ID is required")]
        public int BookId { get; set; }

        [Required(ErrorMessage = "Reader ID is required")]
        public int ReaderId { get; set; }

        [Display(Name = "Borrow Date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Borrow date is required")]
        public DateTime BorrowDate { get; set; }

        [Display(Name = "Return Date")]
        [DataType(DataType.Date)]
        public DateTime? ReturnDate { get; set; }
    }
}
