using Server.Entities;

namespace Server.Dto;

public class GetAllAccessRequestsResponseDto
{
	public List<AccessRequest> Data { get; set; } = null!;
	public int RecordCount { get; set; }
}