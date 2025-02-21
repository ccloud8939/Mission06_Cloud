using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Cloud.Models;

public class Movie
{
    [Key]
    
    public int MovieId { get; set; } // Primary Key
    
    // Foreign Key Relationship
    public int CategoryId { get; set; } // Ensure this matches `Category.Id`
    public virtual Category Category { get; set; }
    
    [Required]
    public string Title { get; set; } // Ensure this field is required

    [Required]
    public int Year { get; set; }

   
    public string Director { get; set; }//optional
    
    public string Rating { get; set; }//optional

    [Required]
    public bool Edited { get; set; }

    public string? LentTo { get; set; }// optional
    
    [Required]
    public bool CopiedToPlex { get; set; } // Changed from int to bool (if it's a flag)

    [StringLength(25, ErrorMessage = "Notes cannot be longer than 25 characters.")]
    public string? Notes { get; set; } //optional

    
}
    