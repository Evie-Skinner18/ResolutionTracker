using ResolutionTracker.Data.Models.Common;

namespace ResolutionTracker.Data.DataAccess.Common
{
    // this service can wirte to the DB
    public interface IResolutionWriter
    {
        void AddResolution(Resolution newResolution);
        void UpdateResolution(Resolution resolutionToUpdate);
        void DeleteResolution(Resolution resolutionToDelete);
    }
}
