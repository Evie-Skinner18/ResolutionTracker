using ResolutionTracker.Data.Models.Common;

namespace ResolutionTracker.Services.Common
{
    // this service can wirte to the DB
    public interface IResolutionWriterService
    {
        void AddResolution(Resolution newResolution);
    }
}
