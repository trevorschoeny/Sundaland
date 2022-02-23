using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sundaland.Models;
using Sundaland.Models.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sundaland.Controllers
{
    public class HomeController : Controller
    {
        private IBookstoreRepository repo;

        public HomeController(IBookstoreRepository temp) => repo = temp;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Booklist(int pageNum = 1)
        {
            int pageSize = 10;

            var bookListViewModel = new BookListViewModel
            {
                Books = repo.Books
                    .OrderBy(b => b.Title)
                    .Skip(pageSize * (pageNum - 1))
                    .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumBooks = repo.Books.Count(),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };
            return View(bookListViewModel);
        }
    }
}
