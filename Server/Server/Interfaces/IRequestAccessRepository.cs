using Server.Dto;

namespace Server.Interfaces;

public interface IRequestAccessRepository
{
    Task<IResult> GetAllAccessRequests();
    Task<IResult> CreateNewAccessRequest(CreateNewAccessRequestDto request);
}