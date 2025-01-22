using NzWalks.API.Model.Domain;
using NzWalks.API.Model.Dto;

namespace NzWalks.API.Repository
{
    public interface IRegionRepository
    {

       Task<List<RegionDto>> GetAllRegions();

        Task<RegionDto> GetRegionById(Guid id);

        Task<Region> AddRegion(RegionDto regionDto);

        Task<RegionDto> DeleteRegion(Guid regionId);

        Task<RegionDto> UpadteRegion(Guid id, RegionDto regionDto);
    }
}
