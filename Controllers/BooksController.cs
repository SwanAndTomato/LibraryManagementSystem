using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

public class BooksController : Controller
{
    private readonly BookRepository _bookRepository;

    public BooksController(BookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public IActionResult Index()
    {
        var books = _bookRepository.GetAllBooks();
        return View(books);
    }

    public IActionResult Details(int id)
    {
        var book = _bookRepository.GetBookById(id);
        if (book == null)
        {
            return NotFound();
        }
        return View(book);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]

    [ValidateAntiForgeryToken]
    public IActionResult Create(BookModel book)
    {
        if (ModelState.IsValid)
        {
            _bookRepository.AddBook(book);
            return RedirectToAction(nameof(Index));
        }
        return View(book);
    }

    public IActionResult Edit(int id)
    {
        var book = _bookRepository.GetBookById(id);
        if (book == null)
        {
            return NotFound();
        }
        return View(book);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, BookModel book)
    {
        if (id != book.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            _bookRepository.UpdateBook(book);
            return RedirectToAction(nameof(Index));
        }
        return View(book);
    }

    public IActionResult Delete(int id)
    {
        var book = _bookRepository.GetBookById(id);
        if (book == null)
        {
            return NotFound();
        }

        return View(book);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        _bookRepository.DeleteBook(id);
        return RedirectToAction(nameof(Index));
    }
}
