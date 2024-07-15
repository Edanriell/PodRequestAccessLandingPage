namespace Server.Entities;

public class AccessRequest
{
	public Guid Id { get; init; }
	public string Email { get; init; } = string.Empty;
}