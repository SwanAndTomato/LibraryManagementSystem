using Microsoft.AspNetCore.Mvc;
using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryManagementSystem.Controllers
{
    public class BorrowingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BorrowingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Borrowings
        public IActionResult Index()
        {
            var borrowings = _context.Borrowings.ToList();
            return View(borrowings);
        }

        // GET: Borrowings/Create
        public IActionResult Create()
        {
            // Retrieve available books from the database and populate the Books property
            var borrowingModel = new BorrowingModel
            {
                Books = _context.Books.ToList(),
                Readers = _context.Readers.ToList(),
                // Other initialization if needed
            };
            return View(borrowingModel);
        }

        // POST: Borrowings/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BorrowingModel borrowing)
        {
            ModelState.Remove("Book");
            ModelState.Remove("Reader");

            if (ModelState.IsValid)
            {
                // Retrieve the related BookModel and ReaderModel based on the IDs.
                borrowing.Book = await _context.Books.FindAsync(borrowing.BookId);
                borrowing.Reader = await _context.Readers.FindAsync(borrowing.ReaderId);

                // Check if both the Book and Reader with the given IDs were found.
                if (borrowing.Book == null || borrowing.Reader == null)
                {
                    // Handle the case where the book or reader doesn't exist.
                    // Add error messages to ModelState or return a suitable response.
                    ModelState.AddModelError("", "The book or reader does not exist.");
                    // Re-populate ViewData as it was in the GET method for AddBorrowing.
                    ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Title");
                    ViewData["ReaderId"] = new SelectList(_context.Readers, "ReaderId", "Name");
                    return View(borrowing);
                }

                borrowing.Book.IsAvailable = false;
                // If both entities exist, then proceed to add the borrowing to the database.
                await _context.Borrowings.AddAsync(borrowing);
                await _context.SaveChangesAsync();
                return RedirectToAction("GetAllBorrowings");
            }
            if (!ModelState.IsValid)
            {
                foreach (var entry in ModelState)
                {
                    if (entry.Value.Errors.Count > 0)
                    {
                        Console.WriteLine($"Error in {entry.Key}:");
                        foreach (var error in entry.Value.Errors)
                        {
                            Console.WriteLine($" - {error.ErrorMessage}");
                        }
                    }
                }
            }

            // If model state is not valid, return the view with the current model to show validation errors.
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Title", borrowing.BookId);
            ViewData["ReaderId"] = new SelectList(_context.Readers, "ReaderId", "Name", borrowing.ReaderId);
            return View(borrowing);
        }
        // GET: Borrowings/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrowing = _context.Borrowings.Find(id);
            if (borrowing == null)
            {
                return NotFound();
            }
            return View(borrowing);
        }

        // POST: Borrowings/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,BookTitle,ReaderName,BorrowDate,ReturnDate")] BorrowingModel borrowing)
        {
            if (id != borrowing.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(borrowing);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BorrowingExists(borrowing.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(borrowing);
        }

        // GET: Borrowings/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrowing = _context.Borrowings.Find(id);
            if (borrowing == null)
            {
                return NotFound();
            }

            return View(borrowing);
        }

        // POST: Borrowings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var borrowing = _context.Borrowings.Find(id);
            _context.Borrowings.Remove(borrowing);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool BorrowingExists(int id)
        {
            return _context.Borrowings.Any(e => e.Id == id);
        }
    }
}
