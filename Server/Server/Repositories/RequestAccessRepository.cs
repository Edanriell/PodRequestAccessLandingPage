using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Dto;
using Server.Entities;
using Server.Interfaces;

namespace Server.Repositories;

public class RequestAccessRepository(ApplicationDbContext context) : IRequestAccessRepository
{
	public async Task<IResult> GetAllAccessRequests()
	{
		var query = await context.AccessRequests.AsNoTracking().ToListAsync();

		var recordCount = query.Count;

		if (recordCount == 0)
			return TypedResults.NotFound("No Access Requests have been found in DB.");

		return TypedResults.Ok(
			new GetAllAccessRequestsResponseDto
			{
				Data = query,
				RecordCount = recordCount
			});
	}

	public async Task<IResult> CreateNewAccessRequest(CreateNewAccessRequestDto request)
	{
		var entity = new AccessRequest
		             {
			             Email = request.Email
		             };

		await context.AccessRequests.AddAsync(entity);

		await context.SaveChangesAsync();

		return TypedResults.Ok("New Request Access has been created.");
	}
}