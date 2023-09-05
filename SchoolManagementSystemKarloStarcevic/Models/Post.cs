using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
namespace SchoolManagementSystemKarloStarcevic.Models { 
public class Post
{
    public int Id { get; set; }

    [Required]
    public string Title { get; set; }

    [Required]
    public string Content { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Date of Posting")]
    public DateTime DateOfPosting { get; set; } = DateTime.Now;

    public string UserId { get; set; }
    public IdentityUser User { get; set; }
}
}