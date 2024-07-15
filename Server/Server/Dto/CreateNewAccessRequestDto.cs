using System.ComponentModel.DataAnnotations;

namespace Server.Dto;

public abstract record CreateNewAccessRequestDto
{
	[Required]
	[EmailAddress]
	[MinLength(5)]
	[MaxLength(150)]
	public string Email { get; set; } = string.Empty;
}