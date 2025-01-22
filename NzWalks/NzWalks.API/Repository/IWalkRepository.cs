using NzWalks.API.Model.Domain;
using NzWalks.API.Model.Dto;

namespace NzWalks.API.Repository
{
    public interface IWalkRepository
    {
        Task<IEnumerable<WalkDto>> GetAllWalks();

        Task<WalkDto> GetWalkById(Guid id);

        Task<Walk> CreateWalk(RequestedWalkDto walkdto);

        Task<WalkDto> DeleteWalk(Guid id);

        Task<WalkDto> UpdateWalk( Guid id ,RequestedWalkDto walkDto);
    }
}
