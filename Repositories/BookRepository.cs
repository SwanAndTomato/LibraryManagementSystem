using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagementSystem.Repositories
{

    public class BookRepository
    {
        private readonly List<BookModel> _books;

        public BookRepository()
        {
            _books = new List<BookModel>
        {
            new BookModel { Id = 1, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", ISBN = "9780743273565", Publisher = "Scribner", PublishedDate = new DateTime(1925, 4, 10), IsAvailable = true },
            new BookModel { Id = 2, Title = "To Kill a Mockingbird", Author = "Harper Lee", ISBN = "9780061120084", Publisher = "J. B. Lippincott & Co.", PublishedDate = new DateTime(1960, 7, 11), IsAvailable = true },
            new BookModel { Id = 3, Title = "1984", Author = "George Orwell", ISBN = "9780451524935", Publisher = "Harcourt, Brace & World", PublishedDate = new DateTime(1949, 6, 8), IsAvailable = true },
            new BookModel { Id = 4, Title = "The Catcher in the Rye", Author = "J.D. Salinger", ISBN = "9780316769488", Publisher = "Little, Brown and Company", PublishedDate = new DateTime(1951, 7, 16), IsAvailable = true },
            new BookModel { Id = 5, Title = "Pride and Prejudice", Author = "Jane Austen", ISBN = "9780141439518", Publisher = "Thomas Egerton", PublishedDate = new DateTime(1813, 1, 28), IsAvailable = true },
            new BookModel { Id = 6, Title = "The Hobbit", Author = "J.R.R. Tolkien", ISBN = "9780261102217", Publisher = "Allen & Unwin", PublishedDate = new DateTime(1937, 9, 21), IsAvailable = true },
            new BookModel { Id = 7, Title = "Harry Potter and the Philosopher's Stone", Author = "J.K. Rowling", ISBN = "9780747532743", Publisher = "Bloomsbury", PublishedDate = new DateTime(1997, 6, 26), IsAvailable = true },
            new BookModel { Id = 8, Title = "The Lord of the Rings", Author = "J.R.R. Tolkien", ISBN = "9780261102385", Publisher = "George Allen & Unwin", PublishedDate = new DateTime(1954, 7, 29), IsAvailable = true },
            new BookModel { Id = 9, Title = "Animal Farm", Author = "George Orwell", ISBN = "9780451526342", Publisher = "Secker and Warburg", PublishedDate = new DateTime(1945, 8, 17), IsAvailable = true },
            new BookModel { Id = 10, Title = "The Chronicles of Narnia", Author = "C.S. Lewis", ISBN = "9780066238500", Publisher = "Geoffrey Bles", PublishedDate = new DateTime(1950, 10, 16), IsAvailable = true },
            new BookModel { Id = 11, Title = "Moby-Dick", Author = "Herman Melville", ISBN = "9780142000083", Publisher = "Harper & Brothers", PublishedDate = new DateTime(1851, 10, 18), IsAvailable = true },
            new BookModel { Id = 12, Title = "The Hitchhiker's Guide to the Galaxy", Author = "Douglas Adams", ISBN = "9780345391803", Publisher = "Pan Books", PublishedDate = new DateTime(1979, 10, 12), IsAvailable = true },
            new BookModel { Id = 13, Title = "Brave New World", Author = "Aldous Huxley", ISBN = "9780060850524", Publisher = "Chatto & Windus", PublishedDate = new DateTime(1932, 5, 14), IsAvailable = true },
            new BookModel { Id = 14, Title = "Frankenstein", Author = "Mary Shelley", ISBN = "9780141439471", Publisher = "Lackington, Hughes, Harding, Mavor & Jones", PublishedDate = new DateTime(1818, 1, 1), IsAvailable = true },
            new BookModel { Id = 15, Title = "The Picture of Dorian Gray", Author = "Oscar Wilde", ISBN = "9780141439570", Publisher = "Ward, Lock and Company", PublishedDate = new DateTime(1890, 6, 20), IsAvailable = true },
            new BookModel { Id = 16, Title = "Alice's Adventures in Wonderland", Author = "Lewis Carroll", ISBN = "9780141439761", Publisher = "Macmillan", PublishedDate = new DateTime(1865, 11, 26), IsAvailable = true },
            new BookModel { Id = 17, Title = "Jane Eyre", Author = "Charlotte Brontë", ISBN = "9780141441146", Publisher = "Smith, Elder & Co.", PublishedDate = new DateTime(1847, 10, 16), IsAvailable = true },
            new BookModel { Id = 18, Title = "The Brothers Karamazov", Author = "Fyodor Dostoevsky", ISBN = "9780374528379", Publisher = "The Russian Messenger", PublishedDate = new DateTime(1880, 11, 5), IsAvailable = true },
            new BookModel { Id = 19, Title = "Gone with the Wind", Author = "Margaret Mitchell", ISBN = "9781451635621", Publisher = "Macmillan Publishers", PublishedDate = new DateTime(1936, 6, 30), IsAvailable = true },
            new BookModel { Id = 20, Title = "The Count of Monte Cristo", Author = "Alexandre Dumas", ISBN = "9780140449266", Publisher = "Ponson du Terrail", PublishedDate = new DateTime(1844, 8, 28), IsAvailable = true }
        };
        }

        public IEnumerable<BookModel> GetAllBooks()
        {
            return _books.ToList();
        }

        public BookModel GetBookById(int id)
        {
            return _books.FirstOrDefault(b => b.Id == id);
        }

        public void AddBook(BookModel book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));

            book.Id = _books.Any() ? _books.Max(b => b.Id) + 1 : 1;
            _books.Add(book);
        }

        public void UpdateBook(BookModel book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));

            var existingBook = _books.FirstOrDefault(b => b.Id == book.Id);
            if (existingBook != null)
            {
                existingBook.Title = book.Title;
                existingBook.Author = book.Author;
                existingBook.ISBN = book.ISBN;
                existingBook.Publisher = book.Publisher;
                existingBook.PublishedDate = book.PublishedDate;
                existingBook.IsAvailable = book.IsAvailable;
            }
        }

        public void DeleteBook(int id)
        {
            var bookToDelete = _books.FirstOrDefault(b => b.Id == id);
            if (bookToDelete != null)
                _books.Remove(bookToDelete);
        }
    }
}