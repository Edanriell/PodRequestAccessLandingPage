namespace Server.Routing;

public interface IEndpointRouteHandler
{
	public void MapEndpoints(IEndpointRouteBuilder app);
}