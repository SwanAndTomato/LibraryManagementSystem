using LibraryManagementSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

public class BorrowingRepository
{
    private List<BorrowingModel> borrowings;
    private readonly BookRepository bookRepository;
    private readonly ReaderRepository readerRepository;

    public BorrowingRepository(BookRepository bookRepository, ReaderRepository readerRepository)
    {
        this.bookRepository = bookRepository;
        this.readerRepository = readerRepository;

        // Initialize the repository with some example data
        borrowings = new List<BorrowingModel>
        {
            new BorrowingModel
            {
                Id = 1,
                BookId = 1,
                BookTitle = bookRepository.GetBookById(1).Title,
                ReaderId = 1,
                ReaderName = readerRepository.GetReaderById(1).Name,
                BorrowDate = new DateTime(2024, 3, 1),
                ReturnDate = null
            },
            new BorrowingModel
            {
                Id = 2,
                BookId = 2,
                BookTitle = bookRepository.GetBookById(2).Title,
                ReaderId = 2,
                ReaderName = readerRepository.GetReaderById(2).Name,
                BorrowDate = new DateTime(2024, 3, 5),
                ReturnDate = new DateTime(2024, 3, 15)
            },
            new BorrowingModel
            {
                Id = 3,
                BookId = 3,
                BookTitle = bookRepository.GetBookById(3).Title,
                ReaderId = 3,
                ReaderName = readerRepository.GetReaderById(3).Name,
                BorrowDate = new DateTime(2024, 1, 5),
                ReturnDate = null
            },
            new BorrowingModel
            {
                Id = 4,
                BookId = 4,
                BookTitle = bookRepository.GetBookById(4).Title,
                ReaderId = 4,
                ReaderName = readerRepository.GetReaderById(4).Name,
                BorrowDate = new DateTime(2023, 12, 15),
                ReturnDate = new DateTime(2024, 1, 23)
            },
            new BorrowingModel
            {
                Id = 5,
                BookId = 5,
                BookTitle = bookRepository.GetBookById(5).Title,
                ReaderId = 5,
                ReaderName = readerRepository.GetReaderById(5).Name,
                BorrowDate = new DateTime(2024, 2, 15),
                ReturnDate = new DateTime(2024, 2, 29)
            },
            // Add more example borrowings as needed
        };
    }

    public IEnumerable<BorrowingModel> GetAllBorrowings()
    {
        return borrowings;
    }

    public BorrowingModel GetBorrowingById(int id)
    {
        return borrowings.FirstOrDefault(b => b.Id == id);
    }

    public void AddBorrowing(BorrowingModel borrowing)
    {
        borrowing.Id = borrowings.Count + 1;
        borrowing.BookTitle = bookRepository.GetBookById(borrowing.BookId).Title;
        borrowing.ReaderName = readerRepository.GetReaderById(borrowing.ReaderId).Name;
        borrowings.Add(borrowing);
    }

    public void UpdateBorrowing(BorrowingModel borrowing)
    {
        var existingBorrowing = borrowings.FirstOrDefault(b => b.Id == borrowing.Id);
        if (existingBorrowing != null)
        {
            existingBorrowing.BookId = borrowing.BookId;
            existingBorrowing.BookTitle = bookRepository.GetBookById(borrowing.BookId).Title;
            existingBorrowing.ReaderId = borrowing.ReaderId;
            existingBorrowing.ReaderName = readerRepository.GetReaderById(borrowing.ReaderId).Name;
            existingBorrowing.BorrowDate = borrowing.BorrowDate;
            existingBorrowing.ReturnDate = borrowing.ReturnDate;
        }
    }

    public void DeleteBorrowing(int id)
    {
        var borrowingToDelete = borrowings.FirstOrDefault(b => b.Id == id);
        if (borrowingToDelete != null)
        {
            borrowings.Remove(borrowingToDelete);
        }
    }
}
