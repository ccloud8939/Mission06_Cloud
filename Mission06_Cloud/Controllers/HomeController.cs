using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var categories = _context.Categories
                .OrderBy(c => c.CategoryName)
                .ToList();

            if (categories.Count == 0)
            {
                ModelState.AddModelError("", "No categories available. Please add categories first.");
            }

            ViewBag.Categories = categories;
            return View("NewMovieForm", new Movie());
        }
        [HttpPost]
        public IActionResult NewMovieForm(Movie response)
        {
            if (ModelState.IsValid)
            {
                // Validate that the selected category exists
                if (response.CategoryId == null || !_context.Categories.Any(c => c.CategoryId == response.CategoryId))
                {
                    ModelState.AddModelError("CategoryId", "Invalid category selected.");
                    ViewBag.Categories = _context.Categories.OrderBy(c => c.CategoryName).ToList();
                    return View("NewMovieForm", response); // Pass the response object back
                }

                _context.Movies.Add(response); // add to the database
                _context.SaveChanges(); // Save changes to the database
                return RedirectToAction("Collection"); // Redirect after successful save
            }
            else
            {
                ViewBag.Categories = _context.Categories
                    .OrderBy(c => c.CategoryName)
                    .ToList();
                return View("NewMovieForm", response); // Return to the form with validation errors
            }
        }

        public IActionResult Collection()
        {
            try
            {
                // get movies from the database
                var movies = _context.Movies.Include(m => m.Category).ToList();
                
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