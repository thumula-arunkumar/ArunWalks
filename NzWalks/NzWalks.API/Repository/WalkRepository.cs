using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NzWalks.API.Data;
using NzWalks.API.Model.Domain;
using NzWalks.API.Model.Dto;

namespace NzWalks.API.Repository
{
    public class WalkRepository : IWalkRepository
    {
        private readonly NzWalksDbContext nzWalksDbContext;
        private readonly IMapper mapper;

        public WalkRepository(NzWalksDbContext nzWalksDbContext, IMapper mapper)
        {
            this.nzWalksDbContext = nzWalksDbContext;
            this.mapper = mapper;
        }

        public async Task<Walk> CreateWalk(RequestedWalkDto walkdto)
        {
            //Convert it to the domain Model
            var walkDomain = mapper.Map<Walk>(walkdto);
            walkDomain.Id = Guid.NewGuid();

            await nzWalksDbContext.Walks.AddAsync(walkDomain);
            await nzWalksDbContext.SaveChangesAsync();

            return walkDomain;
        }

        public async Task<WalkDto> DeleteWalk(Guid id)
        {
            var walkDomain = await nzWalksDbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if (walkDomain == null)
            {
                return null;
            } 
            nzWalksDbContext.Walks.Remove(walkDomain);
            await nzWalksDbContext.SaveChangesAsync(); 

            //Map to dto 
            var walkDto = mapper.Map<WalkDto>(walkDomain);

            return walkDto;
        }

        public async Task<IEnumerable<WalkDto>> GetAllWalks()
        {
            // Fetching the data from the database
            var walkDomains = await nzWalksDbContext.Walks
                .Include(x => x.Region)
                .Include(x => x.WalkDifficulty)
                .ToListAsync();

            // Mapping the domain objects to DTOs
            var walkDtos = mapper.Map<List<WalkDto>>(walkDomains); 

            return walkDtos;
        }

        public async Task<WalkDto> GetWalkById(Guid id)
        {
            var walkModel = await nzWalksDbContext.Walks
                .Include(x => x.Region) 
                .Include(x => x.WalkDifficulty)
                .FirstOrDefaultAsync(x => x.Id == id);

            var wakDto = mapper.Map<WalkDto>(walkModel);

            return wakDto;

        }

        public async Task<WalkDto> UpdateWalk(Guid id, RequestedWalkDto walkDto)
        {
            var existingWalk = await nzWalksDbContext.Walks.Include(x => x.Region).Include(x => x.WalkDifficulty).FirstOrDefaultAsync(x => x.Id == id); 

            if(existingWalk == null)
            {
                return null;
            }

            existingWalk.Name = walkDto.Name;
            existingWalk.length = walkDto.length;
            existingWalk.RegionId = walkDto.RegionId;
            existingWalk.WalkDifficultyId = walkDto.WalkDifficultyId;

            await nzWalksDbContext.SaveChangesAsync(); 

            //map to dto 

            var walkdto = mapper.Map<WalkDto>(existingWalk);

            return walkdto;


        }
    }
}
;