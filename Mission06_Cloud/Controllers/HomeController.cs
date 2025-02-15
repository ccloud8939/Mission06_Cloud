using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_Cloud.Models;
using SQLitePCL;

namespace Mission06_Cloud.Controllers;

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
        return View("NewMovieForm");
    }
    [HttpPost]
    public IActionResult NewMovieForm(Form response)
    {
        _context.Forms.Add(response);// record to the database
        _context.SaveChanges(); //save the changes in the database
        return View();
    }
}