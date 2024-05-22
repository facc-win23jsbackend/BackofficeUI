using System.ComponentModel.DataAnnotations;

namespace BackOfficeUI.Models;

public class Customer
{
    public string? UserId { get; set; }
    public int Id { get; set; }
    [Display(Name = "First name")]
    [Required(ErrorMessage = "First name is required.")]
    public string FirstName { get; set; } = null!;
    
    [Display(Name = "Last name")]
    [Required(ErrorMessage = "Last name is required.")]
    public string LastName { get; set; } = null!;
    
    [Display(Name = "Email")]
    [Required(ErrorMessage = "Email is required.")]
    public string Email { get; set; } = null!;
    public string? PhoneNumber { get; set; }
    public string? Biography { get; set; }
    
    [Display(Name = "Street name")]
    [Required(ErrorMessage = "Street name is required.")]
    public string StreetName { get; set; } = null!;
    public string? StreetName_2 { get; set; }
    
    [Display(Name = "Postal Code")]
    [Required(ErrorMessage = "Postal Code is required.")]
    public string PostalCode { get; set; } = null!;
    
    [Display(Name = "City")]
    [Required(ErrorMessage = "City is required.")]
    public string City { get; set; } = null!;
}