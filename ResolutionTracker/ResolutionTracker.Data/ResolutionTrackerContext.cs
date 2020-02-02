using Microsoft.EntityFrameworkCore;
using ResolutionTracker.Data.Common;
using ResolutionTracker.Data.Models;

namespace ResolutionTracker.Data
{
    public class ResolutionTrackerContext : DbContext
    {
        public ResolutionTrackerContext(DbContextOptions options) : base (options) { }

        // each DB Set is a table
        public DbSet <Resolution> Resolutions { get; set; }
        public DbSet<HealthResolution> HealthResolutions { get; set; }
        public DbSet <MusicResolution> MusicResolutions { get; set; }
        public DbSet <CodingResolution> CodingResolutions { get; set; }
        public DbSet <LanguageResolution> LanguageResolutions { get; set; }
    }
}
