using System.ComponentModel.DataAnnotations;

public class GainAccessModel
{
    [Required(ErrorMessage = "Email address is required")]
    [EmailAddress(ErrorMessage = "Oops! Please check your email")]
    public string Email { get; set; } = null!;
}