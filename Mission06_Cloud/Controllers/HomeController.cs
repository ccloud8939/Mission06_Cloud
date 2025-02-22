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
            return View("NewMovieForm", new Movie());
        }

        [HttpPost]
        public IActionResult NewMovieForm(Movie response)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response); // record to the database
                _context.SaveChanges(); //save the changes in the database
                return View();
            }
            else //invalid data
            {
                ViewBag.Categories = _context.Categories
                    .OrderBy(c => c.CategoryName)
                    .ToList();
                
                return View("NewMovieForm");
                
            }
            
        }

        public IActionResult Collection()
        {
            try
            {
                // Fetch movies from the database
                var movies = _context.Movies
                    .Where(movie => movie.MovieId != 0 && 
                                    movie.CategoryId != 0 && 
                                    !string.IsNullOrEmpty(movie.Title) && 
                                    movie.Year > 0 && 
                                    movie.Edited && // No need to check for null, it's a bool
                                    movie.CopiedToPlex) // No need to check for null, it's a bool
                    .ToList();

                return View(movies); // Pass the list of movies to the view
            }
            catch (InvalidOperationException ex)
            {
                // Log the exception (optional)
                ModelState.AddModelError("", "An error occurred while retrieving the movies.");
                return View(new List<Movie>()); // Return an empty list to avoid null reference in the view
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Movies
                .Where(x => x.MovieId == id).FirstOrDefault();
            
            ViewBag.Categories = _context.Categories
                .OrderBy(c => c.CategoryName)
                .ToList();
            
            return View("NewMovieForm", recordToEdit);
            
        }

        [HttpPost]
        public IActionResult Edit(Movie updatedMovie)
        {
            _context.Update(updatedMovie);
            _context.SaveChanges();

            return RedirectToAction("Collection");

        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
           var recordToDelete = _context.Movies 
               .Single(x => x.MovieId == id);
           return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Movie recordToDelete)
        {
            _context.Movies.Remove(recordToDelete);
            _context.SaveChanges();
            return RedirectToAction("Collection");
        }
    }
    
}