using System.ComponentModel.DataAnnotations;

namespace Mission06_Cloud.Models;

public class Form
{
    [Key]
    [Required]
    public string Category { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public int Year { get; set; }
    [Required]
    public string Director { get; set; }
    [Required]
    public string Rating { get; set; }
    
    // these fields are optional below
    public bool Edited {get; set;}
    
    public string? lent { get; set; }
    
    [StringLength(25, ErrorMessage = "Notes cannot be longer than 25 characters.")]
    public string? Notes { get; set; } //max length is 25 characters
    
    
    
}


    