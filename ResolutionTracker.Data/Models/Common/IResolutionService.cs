using System;
using System.Collections.Generic;

namespace ResolutionTracker.Data.Common
{
    public interface IResolutionService
    {
        IEnumerable<Resolution> GetAllResolutions();
        Resolution GetResolutionById(int id);
        void AddResolution(Resolution newResolution);

        string GetTitle(int id);
        string GetDescription(int id);
        DateTime GetDeadline(int id);
        DateTime GetDateCompleted(int id);
        int GetPercentageComplete(int id);
    }
}
