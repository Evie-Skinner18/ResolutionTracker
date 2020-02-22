using ResolutionTracker.Data;
using ResolutionTracker.Data.Models.Common;
using ResolutionTracker.Services.Common;

namespace ResolutionTracker.Services
{
    public class ResolutionWriterService : IResolutionWriterService
    {
        private ResolutionTrackerContext _resolutionTrackerContext;

        public ResolutionWriterService(ResolutionTrackerContext resolutionTrackerContext)
        {
            _resolutionTrackerContext = resolutionTrackerContext;
        }

        public void AddResolution(Resolution newResolution)
        {
            _resolutionTrackerContext.Add(newResolution);
            _resolutionTrackerContext.SaveChanges();
        }
    }
}
