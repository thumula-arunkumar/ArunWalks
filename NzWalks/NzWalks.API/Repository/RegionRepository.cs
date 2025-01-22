using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NzWalks.API.Data;
using NzWalks.API.Model.Domain;
using NzWalks.API.Model.Dto;

namespace NzWalks.API.Repository
{
    public class RegionRepository : IRegionRepository
    {
        private readonly NzWalksDbContext nzWalksDbContext;
        private readonly IMapper mapper;

        public RegionRepository(NzWalksDbContext nzWalksDbContext, IMapper mapper)
        {
            this.nzWalksDbContext = nzWalksDbContext;
            this.mapper = mapper;
        }
        public async Task<List<RegionDto>> GetAllRegions()
        {
            //List<RegionDto> regionsDto = new List<RegionDto>();
            var regions = await  nzWalksDbContext.Regions.ToListAsync();
            var regionsDto = new List<RegionDto>();

            regionsDto = mapper.Map(regions, regionsDto);
            //foreach (var region in regions)
            //{
            //    regionsDto.Add(new RegionDto()
            //    {
            //        Name = region.Name,
            //        Code = region.Code,
            //        Area = region.Area,
            //        Lat = region.Lat,
            //        Long = region.Long,
            //        Population = region.Population,
            //    });
            //}

            return regionsDto;
        }

        public async Task<RegionDto> GetRegionById(Guid id)
        {
            var region = await nzWalksDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            
            var regionDto =  mapper.Map<RegionDto>(region);

            //var regionDto = new RegionDto()
            //{
            //    Name = region.Name,
            //    Code = region.Code,
            //    Area = region.Area,
            //    Lat = region.Lat,
            //    Long = region.Long,
            //    Population = region.Population
            //};
            return regionDto;
        } 
    }
}
