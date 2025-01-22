using NzWalks.API.Model.Domain;
using NzWalks.API.Model.Dto;

namespace NzWalks.API.Repository
{
    public interface IRegionRepository
    {

       Task<List<RegionDto>> GetAllRegions();

        Task<RegionDto> GetRegionById(Guid id);
    }
}
