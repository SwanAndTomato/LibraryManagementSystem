using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

public class BorrowingsController : Controller
{
    private readonly BorrowingRepository _borrowingRepository;

    public BorrowingsController(BorrowingRepository borrowingRepository)
    {
        _borrowingRepository = borrowingRepository;
    }

    public IActionResult Index()
    {
        var borrowings = _borrowingRepository.GetAllBorrowings();
        return View(borrowings);
    }

    public IActionResult Details(int id)
    {
        var borrowing = _borrowingRepository.GetBorrowingById(id);
        if (borrowing == null)
        {
            return NotFound();
        }
        return View(borrowing);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(BorrowingModel borrowing)
    {
        if (ModelState.IsValid)
        {
            _borrowingRepository.AddBorrowing(borrowing);
            return RedirectToAction(nameof(Index));
        }
        return View(borrowing);
    }

    public IActionResult Edit(int id)
    {
        var borrowing = _borrowingRepository.GetBorrowingById(id);
        if (borrowing == null)
        {
            return NotFound();
        }
        return View(borrowing);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, BorrowingModel borrowing)
    {
        if (id != borrowing.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            _borrowingRepository.UpdateBorrowing(borrowing);
            return RedirectToAction(nameof(Index));
        }
        return View(borrowing);
    }

    public IActionResult Delete(int id)
    {
        var borrowing = _borrowingRepository.GetBorrowingById(id);
        if (borrowing == null)
        {
            return NotFound();
        }

        return View(borrowing);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        _borrowingRepository.DeleteBorrowing(id);
        return RedirectToAction(nameof(Index));
    }
}
