using System;
using System.Collections.Generic;

namespace ResolutionTracker.Data.Models.Common
{
    public interface IResolutionService
    {
        IEnumerable<Resolution> GetAllResolutions();
        Resolution GetResolutionById(int id);
        void AddResolution(Resolution newResolution);

        // details for any kind of resolution
        string GetTitle(int id);
        string GetDescription(int id);
        DateTime GetDeadline(int id);
        DateTime GetDateCompleted(int id);
        int GetPercentageComplete(int id);

        // music details
        string GetMusicGenre(int id);
        string GetInstrument(int id);

        // health details
        string GetHealthArea(int id);

        // coding details
        string GetTechnology(int id);

        // language details
        string GetLanguage(int id);
        string GetSkill(int id);
    }
}
