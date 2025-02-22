using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Cloud.Models;

public class Movie
{
    [Key]
    [Required]
    public int MovieId { get; set; } // Primary Key NOT NULL
    
    // Foreign Key Relationship
    [ForeignKey("CategoryId")]
    public int? CategoryId { get; set; } // Ensure this matches `Category.Id`NOT NULL
    public virtual Category? Category { get; set; }
    
    [Required(ErrorMessage = "Please enter the title of the movie.")]
    public string Title { get; set; } // Ensure this field is required NOT NULL

    [Required]
    [Range(1888, int.MaxValue, ErrorMessage = "Year must be 1888 or later.")]
    public int Year { get; set; } // NOT NULL, must be 1888 or later

   
    public string? Director { get; set; }//optional 
    
    public string? Rating { get; set; }//optional

    [Required(ErrorMessage = "Please enter if the movie was edited or not edited.")]
    public bool Edited { get; set; } // NOT NULL

    public string? LentTo { get; set; }// optional
    
    [Required(ErrorMessage = "Please enter if the movie was copied to plex.")]
    public bool CopiedToPlex { get; set; } // Changed from int to bool (if it's a flag) NOT NULL

    [StringLength(25, ErrorMessage = "Notes cannot be longer than 25 characters.")]
    public string? Notes { get; set; } //optional

    
}
    