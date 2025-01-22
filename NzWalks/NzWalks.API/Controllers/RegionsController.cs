using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NzWalks.API.Data;
using NzWalks.API.Model.Domain;
using NzWalks.API.Model.Dto;
using NzWalks.API.Repository;

namespace NzWalks.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegionsController : Controller
    {
        private readonly IRegionRepository regionRepository;

        public RegionsController(IRegionRepository regionRepository)
        {
            this.regionRepository = regionRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
        {

            var regions = await  regionRepository.GetAllRegions();
            return Ok(regions);

        }


        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetRegionById")]
        public async Task<IActionResult> GetRegionById([FromRoute] Guid id)
        {
            var regionDto = await regionRepository.GetRegionById(id);

            return Ok(regionDto);
        }


        [HttpPost]
        public async Task<IActionResult> AddRegion( RegionDto region)
        {
            var regionDomain = await regionRepository.AddRegion(region);


            return CreatedAtAction("GetRegionById", new { id = regionDomain.Id }, regionDomain);
        }

        [HttpDelete]
        [Route("{id:guid}")] 

        public async Task<IActionResult> DeleteRegion(Guid id)
        {
            var regionDto = await regionRepository.DeleteRegion(id);

            return Ok(regionDto);
        }


        [HttpPut]

        public async Task<IActionResult> UpdateRegion(Guid id, RegionDto region)
        {
            var regionDto = await regionRepository.UpadteRegion(id, region);

            return Ok(regionDto);
        }


    }
}
