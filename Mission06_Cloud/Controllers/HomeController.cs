using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_Cloud.Models;
using SQLitePCL;

namespace Mission06_Cloud.Controllers
{


    public class HomeController : Controller
    {
        private FormContext _context;

        public HomeController(FormContext someMovie) //constructor
        {
            _context = someMovie;
        }

        public IActionResult Index()
        {
            return View("Index");
        }

        public IActionResult GetToKnowJoel()
        {
            return View();
        }

        [HttpGet]
        public IActionResult NewMovieForm()
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(c => c.CategoryName)
                .ToList();
            return View("NewMovieForm");
        }

        [HttpPost]
        public IActionResult NewMovieForm(Movie response)
        {
            _context.Movies.Add(response); // record to the database
            _context.SaveChanges(); //save the changes in the database
            return View();
        }

        public IActionResult Collection()
        {
            var movies = _context.Movies
                .OrderBy(x => x.Title)
                .ToList();

            foreach (var movie in movies)
            {
                _context.Entry(movie)
                    .Reference(f => f.Category) // Load the related Category
                    .Load();
            }

            return View();
        }


        //public IActionResult Collection()
        //{
            //link
            //var forms = _context.Forms
             //   .OrderBy(x => x.Title).ToList();
           // return View(forms);
       // }

        public IActionResult Edit()
        {
            return View("NewMovieForm");
        }
    }
    
}