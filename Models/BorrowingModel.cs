using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class BorrowingModel
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int ReaderId { get; set; }

        [Required(ErrorMessage = "Please select a book.")]
        [Display(Name = "Book")]
        public string BookTitle { get; set; }

        [Required(ErrorMessage = "Please select a reader.")]
        [Display(Name = "Reader")]
        public string ReaderName { get; set; }

        [Required(ErrorMessage = "Please enter the borrow date.")]
        [Display(Name = "Borrow Date")]
        public DateOnly BorrowDate { get; set; }

        [Display(Name = "Return Date")]
        public DateOnly ReturnDate { get; set; }

        // Navigation properties
        public BookModel Book { get; set; }
        public ReaderModel Reader { get; set; }

        // Additional properties for dropdown lists
        public IEnumerable<BookModel> Books { get; set; }
        public IEnumerable<ReaderModel> Readers { get; set; }
    }
}
