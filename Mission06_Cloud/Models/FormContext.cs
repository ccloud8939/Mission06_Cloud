using Microsoft.EntityFrameworkCore;

namespace Mission06_Cloud.Models;

public class FormContext : DbContext
{
    public FormContext(DbContextOptions<FormContext> options) : base(options) //constructor
    {
        
    }
    // table name in db = Forms
    public DbSet<Form> Forms { get; set; }
    
}