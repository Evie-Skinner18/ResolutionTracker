using System;
using ResolutionTracker.ViewModels;

namespace ResolutionTracker.Services.Common
{
    // these methods are in service layer because they involve e.g conditional logic: more than just DB reading or writing
    public interface IResolutionService
    {
        // Index
        ResolutionIndexModel GetResolutionIndexObject();

        // Detail
        ResolutionDetailModel GetResolutionDetailObject(int id);

        // Create


        // Edit


        // Delete
        string GetResolutionType(int id);

    }
}
