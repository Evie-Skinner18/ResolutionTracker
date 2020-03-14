using System;
using ResolutionTracker.Data.Models.Common;
using ResolutionTracker.ViewModels;
using ResolutionTracker.ViewModels.Common;

namespace ResolutionTracker.Services.Common
{
    // these methods are in service layer because they involve e.g conditional logic: more than just DB reading or writing
    public interface IResolutionService
    {
        string GetResolutionType(int id);

        

        // logic to decide what type of resolution this is
        Resolution GetResolutionFromUserInput(ResolutionChangeModel resolution);
        Resolution GetResolutionToEdit(int id, ResolutionEditModel resolution);

        // Index
        ResolutionIndexModel GetResolutionIndexObject();

        // Detail
        ResolutionDetailModel GetResolutionDetailObject(int id);

        // Create
        void CreateResolution(Resolution resolution);

        // Edit
        void CheckResolutionToEdit(Resolution resolution);

        // Delete

    }
}
