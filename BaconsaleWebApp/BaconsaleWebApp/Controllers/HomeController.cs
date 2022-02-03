using BaconsaleWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace BaconsaleWebApp.Controllers
{
    public class HomeController : Controller
    {


        private MovieApplicationContext daContext { get; set; }

        public HomeController(MovieApplicationContext someName)
        {
            daContext = someName;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Movies()
        {
            ViewBag.Categories = daContext.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Movies(ApplicationResponse ar)
        {

            if(ModelState.IsValid)
            {
                daContext.Add(ar);
                daContext.SaveChanges();

                return View("Confirmation", ar);
            }
            else
            {
                ViewBag.Categories = daContext.Categories.ToList();
                return View(ar);
            }

        }
        [HttpGet]
        public IActionResult MovieList()
        {
            var movies = daContext.responses
                .Include(x => x.Category)
                .ToList();

            return View(movies);


        }
        [HttpGet]
        public IActionResult Edit (int applicationid)
        {
            ViewBag.Categories = daContext.Categories.ToList();

            var application = daContext.responses.Single(x => x.ApplicationId == applicationid);

            return View("Movies", application);
        }
        [HttpPost]
        public IActionResult Edit (ApplicationResponse aredit)
        {
            daContext.Update(aredit);
            daContext.SaveChanges();

            return RedirectToAction("MovieList");
        }


        [HttpGet]
        public IActionResult Delete (int applicationid)
        {
            var movie = daContext.responses.Single(x => x.ApplicationId == applicationid);
            return View(movie);
        }
        [HttpPost]
        public IActionResult Delete(ApplicationResponse ar)
        {
            daContext.responses.Remove(ar);
            daContext.SaveChanges();

            return RedirectToAction("MovieList");
        }
    }
}
