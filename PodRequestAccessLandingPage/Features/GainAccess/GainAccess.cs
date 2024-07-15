using System.ComponentModel.DataAnnotations;

public class GainAccessRequestModel
{
	[Required(ErrorMessage = "Email address is required")]
	[EmailAddress(ErrorMessage = "Oops! Please check your email")]
	public string Email { get; set; } = null!;
}