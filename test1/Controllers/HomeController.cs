using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using test1.Dal;
using test1.Models;

namespace test1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //יצירת טבלת ספריות
        public IActionResult Libraris()
        {
            List<Library> Libraris = Data.Get.Libraris.ToList();
            return View(Libraris);
        }

        public IActionResult create()
        {

            return View(new Library());
        }
        //פתיחת חלונית להוספת מדף
        public IActionResult AddingShelf(int id)
        {
            ViewBag.id = id;
            return View(new shelf());
        }

        //פונקציה שמוסיפה מדף חדש לספרייה
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AddShelf(shelf shelf)
        {
            Library? libraryFromDb = Data.Get.Libraris.FirstOrDefault(l => l.id == shelf.Library_id);
            if (libraryFromDb == null)
            {
                return NotFound();
            }

            shelf.Library = libraryFromDb;  

        

            libraryFromDb.Addshelf(shelf.id);
           
            Data.Get.SaveChanges();
            return RedirectToAction("Libraris");
        }



        //מוסיף ספרייה חדשה
        public IActionResult AddLibrary(Library library)
        {
            Data.Get.Libraris.Add(library);
            Data.Get.SaveChanges();
            return RedirectToAction("Libraris");
        }

        //פתיחת חלונית להוספת ספר חדש
        public IActionResult AddingBoook(int id)
        {
            ViewBag.id = id;
            return View(new Book());
        }

        //פונקציה שמוסיפה ספר חדש לספרייה
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AddBook(Book book)
        {
            shelf? shelfFromDb = Data.Get.shelfs.FirstOrDefault(s => s.id == book.shelf_id);
            if (shelfFromDb == null)
            {
                return NotFound();
            }

            book.shelf = shelfFromDb;

            shelfFromDb.AddBook(book.id);
  
            Data.Get.SaveChanges();
            return RedirectToAction("Libraris");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
