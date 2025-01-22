using NzWalks.API.Model.Domain;

namespace NzWalks.API.Model.Dto
{
    public class WalkDto
    {
        public string Name { get; set; }
        public double length { get; set; }
        public Guid RegionId { get; set; }
        public Guid WalkDifficultyId { get; set; }
        public RegionDto Region { get; set; }
        public WalkDifficultyDto WalkDifficulty { get; set; }
    }
}
