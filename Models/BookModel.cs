using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{

    public class BookModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, ErrorMessage = "Title must be less than 100 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Author is required")]
        [StringLength(100, ErrorMessage = "Author must be less than 100 characters")]
        public string Author { get; set; }

        [Required(ErrorMessage = "ISBN is required")]
        [RegularExpression(@"^\d{10}|\d{13}$", ErrorMessage = "Invalid ISBN format")]
        public string ISBN { get; set; }

        [Display(Name = "Publication Date")]
        [DataType(DataType.Date)]
        public DateTime PublicationDate { get; set; }

        [Display(Name = "Genre")]
        [StringLength(50, ErrorMessage = "Genre must be less than 50 characters")]
        public string Genre { get; set; }

        [Display(Name = "Total Pages")]
        [Range(1, int.MaxValue, ErrorMessage = "Total pages must be a positive number")]
        public int TotalPages { get; set; }

        [Display(Name = "Available Copies")]
        [Range(0, int.MaxValue, ErrorMessage = "Available copies must be a non-negative number")]
        public int AvailableCopies { get; set; }

        [Display(Name = "Publisher")]
        [StringLength(100, ErrorMessage = "Publisher must be less than 100 characters")]
        public string Publisher { get; set; }

        [Display(Name = "Published Date")]
        [DataType(DataType.Date)]
        public DateTime PublishedDate { get; set; }

        [Display(Name = "Is Available")]
        public bool IsAvailable { get; set; }
    }

}