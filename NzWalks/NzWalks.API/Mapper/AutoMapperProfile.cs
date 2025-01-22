using AutoMapper;
using NzWalks.API.Model.Domain;
using NzWalks.API.Model.Dto;

namespace NzWalks.API.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Region, RegionDto>().ReverseMap();
            CreateMap<Walk, WalkDto>().ReverseMap();
            CreateMap<Walk, RequestedWalkDto>().ReverseMap();
            CreateMap<WalkDto, RequestedWalkDto>().ReverseMap();
            CreateMap<WalkDifficulty, WalkDifficultyDto>().ReverseMap();

        }
    }
}
