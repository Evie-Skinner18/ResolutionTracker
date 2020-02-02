using ResolutionTracker.Data.Models.Common;

namespace ResolutionTracker.Data.Models
{
    public class MusicResolution : Resolution
    {
        public string Instrument { get; set; }

        public string MusicGenre { get; set; }
    }
}
