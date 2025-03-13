
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Services;
using LibraryManagementSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LibraryManagementSystem.Controllers
{
    public class BookController : Controller
    {
        private readonly MockDataService _dataService;

        public BookController()
        {
            _dataService = new MockDataService();
        }

        public IActionResult List()
        {
            var books = _dataService.GetAllBooks();
            var bookViewModels = books.Select(b => new BookViewModel
            {
                Id = b.Id,
                Title = b.Title,
                AuthorId = b.AuthorId,
                AuthorFullName = b.Author?.FullName,
                Genre = b.Genre,
                PublishDate = b.PublishDate,
                ISBN = b.ISBN,
                CopiesAvailable = b.CopiesAvailable
            }).ToList();

            return View(bookViewModels);
        }

        public IActionResult Details(int id)
        {
            var book = _dataService.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }

            var viewModel = new BookViewModel
            {
                Id = book.Id,
                Title = book.Title,
                AuthorId = book.AuthorId,
                AuthorFullName = book.Author?.FullName,
                Genre = book.Genre,
                PublishDate = book.PublishDate,
                ISBN = book.ISBN,
                CopiesAvailable = book.CopiesAvailable
            };

            return View(viewModel);
        }

        public IActionResult Create()
        {
            var viewModel = new BookViewModel
            {
                Authors = _dataService.GetAllAuthors()
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BookViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var book = new Book
                {
                    Title = viewModel.Title,
                    AuthorId = viewModel.AuthorId,
                    Genre = viewModel.Genre,
                    PublishDate = viewModel.PublishDate,
                    ISBN = viewModel.ISBN,
                    CopiesAvailable = viewModel.CopiesAvailable
                };

                _dataService.AddBook(book);
                return RedirectToAction(nameof(List));
            }

            viewModel.Authors = _dataService.GetAllAuthors();
            return View(viewModel);
        }

        public IActionResult Edit(int id)
        {
            var book = _dataService.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }

            var viewModel = new BookViewModel
            {
                Id = book.Id,
                Title = book.Title,
                AuthorId = book.AuthorId,
                Genre = book.Genre,
                PublishDate = book.PublishDate,
                ISBN = book.ISBN,
                CopiesAvailable = book.CopiesAvailable,
                Authors = _dataService.GetAllAuthors()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(BookViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var book = new Book
                {
                    Id = viewModel.Id,
                    Title = viewModel.Title,
                    AuthorId = viewModel.AuthorId,
                    Genre = viewModel.Genre,
                    PublishDate = viewModel.PublishDate,
                    ISBN = viewModel.ISBN,
                    CopiesAvailable = viewModel.CopiesAvailable
                };

                _dataService.UpdateBook(book);
                return RedirectToAction(nameof(List));
            }

            viewModel.Authors = _dataService.GetAllAuthors();
            return View(viewModel);
        }

        public IActionResult Delete(int id)
        {
            var book = _dataService.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }

            var viewModel = new BookViewModel
            {
                Id = book.Id,
                Title = book.Title,
                AuthorFullName = book.Author?.FullName,
                Genre = book.Genre,
                PublishDate = book.PublishDate,
                ISBN = book.ISBN,
                CopiesAvailable = book.CopiesAvailable
            };

            return View(viewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _dataService.DeleteBook(id);
            return RedirectToAction(nameof(List));
        }
    }
}