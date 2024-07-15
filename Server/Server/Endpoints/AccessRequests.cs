using Microsoft.AspNetCore.Mvc;
using Server.Dto;
using Server.Interfaces;
using Server.Routing;

namespace Server.Endpoints;

public class AccessRequestsEndpoints
{
	public class AccessRequests : IEndpointRouteHandler
	{
		public void MapEndpoints(IEndpointRouteBuilder app)
		{
			app.MapGet("/api/access-requests", GetAllAccessRequests);
			app.MapPost("/api/access-requests/new", CreateNewAccessRequest);
		}

		private async Task<IResult> GetAllAccessRequests(IRequestAccessRepository requestAccessRepository)
		{
			return await requestAccessRepository.GetAllAccessRequests();
		}

		private async Task<IResult> CreateNewAccessRequest([FromBody] CreateNewAccessRequestDto request,
			IRequestAccessRepository requestAccessRepository)
		{
			return await requestAccessRepository.CreateNewAccessRequest(request);
		}
	}
}