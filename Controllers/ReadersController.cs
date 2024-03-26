using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

public class ReadersController : Controller
{
    private readonly ReaderRepository _readerRepository;

    public ReadersController(ReaderRepository readerRepository)
    {
        _readerRepository = readerRepository;
    }

    public IActionResult Index()
    {
        var readers = _readerRepository.GetAllReaders();
        return View(readers);
    }

    public IActionResult Details(int id)
    {
        var reader = _readerRepository.GetReaderById(id);
        if (reader == null)
        {
            return NotFound();
        }
        return View(reader);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(ReaderModel reader)
    {
        if (ModelState.IsValid)
        {
            _readerRepository.AddReader(reader);
            return RedirectToAction(nameof(Index));
        }
        return View(reader);
    }

    public IActionResult Edit(int id)
    {
        var reader = _readerRepository.GetReaderById(id);
        if (reader == null)
        {
            return NotFound();
        }
        return View(reader);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, ReaderModel reader)
    {
        if (id != reader.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            _readerRepository.UpdateReader(reader);
            return RedirectToAction(nameof(Index));
        }
        return View(reader);
    }

    public IActionResult Delete(int id)
    {
        var reader = _readerRepository.GetReaderById(id);
        if (reader == null)
        {
            return NotFound();
        }

        return View(reader);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        _readerRepository.DeleteReader(id);
        return RedirectToAction(nameof(Index));
    }
}
