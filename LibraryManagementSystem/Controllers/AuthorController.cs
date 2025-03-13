
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Services;
using LibraryManagementSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LibraryManagementSystem.Controllers
{
    public class AuthorController : Controller
    {
        private readonly MockDataService _dataService;

        public AuthorController()
        {
            _dataService = new MockDataService();
        }

        public IActionResult List()
        {
            var authors = _dataService.GetAllAuthors();
            var viewModels = authors.Select(a => new AuthorViewModel
            {
                Id = a.Id,
                FirstName = a.FirstName,
                LastName = a.LastName,
                DateOfBirth = a.DateOfBirth,
                BookCount = a.Books?.Count ?? 0
            }).ToList();

            return View(viewModels);
        }

        public IActionResult Details(int id)
        {
            var author = _dataService.GetAuthorById(id);
            if (author == null)
            {
                return NotFound();
            }

            var viewModel = new AuthorViewModel
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
                DateOfBirth = author.DateOfBirth,
                Books = author.Books?.ToList(),
                BookCount = author.Books?.Count ?? 0
            };

            return View(viewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AuthorViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var author = new Author
                {
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName,
                    DateOfBirth = viewModel.DateOfBirth
                };

                _dataService.AddAuthor(author);
                return RedirectToAction(nameof(List));
            }

            return View(viewModel);
        }

        public IActionResult Edit(int id)
        {
            var author = _dataService.GetAuthorById(id);
            if (author == null)
            {
                return NotFound();
            }

            var viewModel = new AuthorViewModel
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
                DateOfBirth = author.DateOfBirth
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(AuthorViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var author = new Author
                {
                    Id = viewModel.Id,
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName,
                    DateOfBirth = viewModel.DateOfBirth
                };

                _dataService.UpdateAuthor(author);
                return RedirectToAction(nameof(List));
            }

            return View(viewModel);
        }

        public IActionResult Delete(int id)
        {
            var author = _dataService.GetAuthorById(id);
            if (author == null)
            {
                return NotFound();
            }

            var viewModel = new AuthorViewModel
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
                DateOfBirth = author.DateOfBirth,
                BookCount = author.Books?.Count ?? 0
            };

            return View(viewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _dataService.DeleteAuthor(id);
            return RedirectToAction(nameof(List));
        }
    }
}