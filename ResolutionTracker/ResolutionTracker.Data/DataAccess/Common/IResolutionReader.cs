using System;
using System.Collections.Generic;
using ResolutionTracker.Data.Models;
using ResolutionTracker.Data.Models.Common;
using ResolutionTracker.ViewModels;
using ResolutionTracker.ViewModels.Common;

namespace ResolutionTracker.Data.DataAccess.Common
{
    // this service can read from the DB
    public interface IResolutionReader
    {
        IEnumerable<Resolution> GetAllResolutions();
        IEnumerable<Resolution> GetCompletedResolutions();
        Resolution GetResolutionById(int id);

        // details for any kind of resolution
        string GetTitle(int id);
        string GetDescription(int id);
        DateTime GetDeadline(int id);
        bool GetCompletionStatus(int id);
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

        // specific types of resolution
        IEnumerable<MusicResolution> GetMusicResolutions();
        IEnumerable<HealthResolution> GetHealthResolutions();
        IEnumerable<CodingResolution> GetCodingResolutions();
        IEnumerable<LanguageResolution> GetLanguageResolutions();
    }
}
