﻿using AutoMapper.Execution;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NzWalks.API.Model.Dto;
using NzWalks.API.Repository;

namespace NzWalks.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
   
    public class WalkController : Controller
    {
        private readonly IWalkRepository walkRepository;

        public WalkController(IWalkRepository walkRepository)
        {
            this.walkRepository = walkRepository;
        }

        [HttpGet]
        [Authorize(Roles = "reader")]
        public async Task<IActionResult> GetAllWalks()
        {
            var walksDtos = await walkRepository.GetAllWalks();

            return Ok(walksDtos);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetById")]
        [Authorize(Roles = "reader")]
        public async Task<IActionResult> GetWalkById(Guid id)
        {
            var walkDto = await walkRepository.GetWalkById(id); 
            return Ok(walkDto);
        }

        [HttpPost]
        [Authorize(Roles = "writer,reader")]
        public async Task<IActionResult> CreateWalk(RequestedWalkDto walkDto)
        {
            var walk = await walkRepository.CreateWalk(walkDto);

            return CreatedAtAction("GetById", new { id = walk.Id }, walk);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        [Authorize(Roles = "writer,reader")]
        public async Task<IActionResult> DeleteWalk( Guid id)
        {
            var walkDto = await walkRepository.DeleteWalk(id);

            return Ok(walkDto);
        }


        [HttpPut]
        [Authorize(Roles = "writer,reader")]
        public async Task<IActionResult> UpdateWalk(Guid id,RequestedWalkDto walkDto)
        {
            var walkdto = await walkRepository.UpdateWalk(id, walkDto);

            return Ok(walkdto);
        }
    }
}
