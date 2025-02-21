using Microsoft.EntityFrameworkCore;

namespace Mission06_Cloud.Models;

public class FormContext : DbContext //liaison from the app to the database 
{
    public FormContext(DbContextOptions<FormContext> options) : base(options) //constructor
    {
        
    }
    // table name in db = Movies
    public DbSet<Movie> Movies { get; set; }// main table 
    public DbSet<Category> Categories { get; set; }
    
}