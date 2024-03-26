using System;
using System.Collections.Generic;
using System.Linq;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Repositories
{

    public class BorrowingRepository
    {
        private readonly List<BorrowingModel> _borrowings;

        public BorrowingRepository()
        {
            _borrowings = new List<BorrowingModel>
        {
            new BorrowingModel { Id = 1, BookId = 1, ReaderId = 1, BorrowDate = new DateTime(2023, 5, 10), ReturnDate = null },
            new BorrowingModel { Id = 2, BookId = 2, ReaderId = 2, BorrowDate = new DateTime(2023, 6, 15), ReturnDate = null },
            new BorrowingModel { Id = 3, BookId = 3, ReaderId = 3, BorrowDate = new DateTime(2023, 7, 20), ReturnDate = new DateTime(2023, 8, 20) },
            new BorrowingModel { Id = 4, BookId = 4, ReaderId = 4, BorrowDate = new DateTime(2023, 8, 25), ReturnDate = null },
            new BorrowingModel { Id = 5, BookId = 5, ReaderId = 5, BorrowDate = new DateTime(2023, 9, 5), ReturnDate = null },
            new BorrowingModel { Id = 6, BookId = 6, ReaderId = 6, BorrowDate = new DateTime(2023, 9, 10), ReturnDate = new DateTime(2023, 10, 10) },
            new BorrowingModel { Id = 7, BookId = 7, ReaderId = 7, BorrowDate = new DateTime(2023, 10, 15), ReturnDate = null },
            new BorrowingModel { Id = 8, BookId = 8, ReaderId = 8, BorrowDate = new DateTime(2023, 11, 20), ReturnDate = null },
            new BorrowingModel { Id = 9, BookId = 9, ReaderId = 9, BorrowDate = new DateTime(2023, 12, 25), ReturnDate = null },
            new BorrowingModel { Id = 10, BookId = 10, ReaderId = 10, BorrowDate = new DateTime(2024, 1, 5), ReturnDate = null },
            new BorrowingModel { Id = 11, BookId = 11, ReaderId = 11, BorrowDate = new DateTime(2024, 2, 10), ReturnDate = null },
            new BorrowingModel { Id = 12, BookId = 12, ReaderId = 12, BorrowDate = new DateTime(2024, 3, 15), ReturnDate = null },
            new BorrowingModel { Id = 13, BookId = 13, ReaderId = 13, BorrowDate = new DateTime(2024, 4, 20), ReturnDate = null },
            new BorrowingModel { Id = 14, BookId = 14, ReaderId = 14, BorrowDate = new DateTime(2024, 5, 25), ReturnDate = null },
            new BorrowingModel { Id = 15, BookId = 15, ReaderId = 15, BorrowDate = new DateTime(2024, 6, 5), ReturnDate = null },
            new BorrowingModel { Id = 16, BookId = 16, ReaderId = 16, BorrowDate = new DateTime(2024, 7, 10), ReturnDate = null },
            new BorrowingModel { Id = 17, BookId = 17, ReaderId = 17, BorrowDate = new DateTime(2024, 8, 15), ReturnDate = null },
            new BorrowingModel { Id = 18, BookId = 18, ReaderId = 18, BorrowDate = new DateTime(2024, 9, 20), ReturnDate = null },
            new BorrowingModel { Id = 19, BookId = 19, ReaderId = 19, BorrowDate = new DateTime(2024, 10, 25), ReturnDate = null },
            new BorrowingModel { Id = 20, BookId = 20, ReaderId = 20, BorrowDate = new DateTime(2024, 11, 5), ReturnDate = null }
        };
        }

        public IEnumerable<BorrowingModel> GetAllBorrowings()
        {
            return _borrowings.ToList();
        }

        public BorrowingModel GetBorrowingById(int id)
        {
            return _borrowings.FirstOrDefault(b => b.Id == id);
        }

        public void AddBorrowing(BorrowingModel borrowing)
        {
            if (borrowing == null)
                throw new ArgumentNullException(nameof(borrowing));

            borrowing.Id = _borrowings.Any() ? _borrowings.Max(b => b.Id) + 1 : 1;
            _borrowings.Add(borrowing);
        }

        public void UpdateBorrowing(BorrowingModel borrowing)
        {
            if (borrowing == null)
                throw new ArgumentNullException(nameof(borrowing));

            var existingBorrowing = _borrowings.FirstOrDefault(b => b.Id == borrowing.Id);
            if (existingBorrowing != null)
            {
                existingBorrowing.BookId = borrowing.BookId;
                existingBorrowing.ReaderId = borrowing.ReaderId;
                existingBorrowing.BorrowDate = borrowing.BorrowDate;
                existingBorrowing.ReturnDate = borrowing.ReturnDate;
            }
        }

        public void DeleteBorrowing(int id)
        {
            var borrowingToDelete = _borrowings.FirstOrDefault(b => b.Id == id);
            if (borrowingToDelete != null)
                _borrowings.Remove(borrowingToDelete);
        }
    }
}
