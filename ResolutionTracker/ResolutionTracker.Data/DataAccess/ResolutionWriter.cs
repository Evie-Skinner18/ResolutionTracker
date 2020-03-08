using Microsoft.EntityFrameworkCore;
using ResolutionTracker.Data;
using ResolutionTracker.Data.DataAccess.Common;
using ResolutionTracker.Data.Models.Common;

namespace ResolutionTracker.Data.DataAccess
{
    public class ResolutionWriterService : IResolutionWriter
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

        public void UpdateResolution(Resolution resolutionToUpdate)
        {
            _resolutionTrackerContext.Entry(resolutionToUpdate).State = EntityState.Modified;
            _resolutionTrackerContext.SaveChanges();
        }
    }
}
