using System.Collections.Generic;

namespace Catmash.Domain
{
    public class LeaderboardDto
    {
        public int TotalVotes { get; set; }
        public List<ImageDto> TopImages { get; set; }
    }
}
