using System;
using System.ComponentModel.DataAnnotations;

public class BorrowingModel
{
    public int Id { get; set; }

    [Display(Name = "Book")]
    public int BookId { get; set; }

    [Display(Name = "Book Title")]
    public string BookTitle { get; set; }

    [Display(Name = "Reader")]
    public int ReaderId { get; set; }

    [Display(Name = "Reader Name")]
    public string ReaderName { get; set; }

    [Display(Name = "Borrow Date")]
    [DataType(DataType.Date)]
    public DateTime BorrowDate { get; set; }

    [Display(Name = "Return Date")]
    [DataType(DataType.Date)]
    public DateTime? ReturnDate { get; set; }
}
