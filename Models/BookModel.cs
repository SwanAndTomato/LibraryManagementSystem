using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class BookModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Author is required")]
        public string Author { get; set; }

        [Required(ErrorMessage = "ISBN is required")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "Publication Date is required")]
        [Display(Name = "Publication Date")]
        public DateOnly PublicationDate { get; set; }

        [Required(ErrorMessage = "Genre is required")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Total Pages is required")]
        [Display(Name = "Total Pages")]
        public int TotalPages { get; set; }

        [Required(ErrorMessage = "Available Copies is required")]
        [Display(Name = "Available Copies")]
        public int AvailableCopies { get; set; }

        [Required(ErrorMessage = "Is Available status is required")]
        [Display(Name = "Is Available")]
        public bool IsAvailable { get; set; }

        [Required(ErrorMessage = "Publisher is required")]
        public string Publisher { get; set; }

        [Display(Name = "Published Date")]
        public DateOnly PublishedDate { get; set; }
    }
}
