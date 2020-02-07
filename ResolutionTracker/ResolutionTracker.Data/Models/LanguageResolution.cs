using ResolutionTracker.Data.Models.Common;

namespace ResolutionTracker.Data.Models
{
    public class LanguageResolution : Resolution
    {
        public string Language { get; set; }

        // as in reading, writing. listening or speaking
        public string Skill { get; set; }
    }
}
