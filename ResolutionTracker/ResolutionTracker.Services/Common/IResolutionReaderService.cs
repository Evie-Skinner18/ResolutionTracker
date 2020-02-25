using System;
using System.Collections.Generic;
using ResolutionTracker.Data.Models.Common;
using ResolutionTracker.ViewModels;
using ResolutionTracker.ViewModels.Common;

namespace ResolutionTracker.Services.Common
{
    // this service can read from the DB
    public interface IResolutionReaderService
    {
        IEnumerable<Resolution> GetAllResolutions();
        Resolution GetResolutionById(int id);

        // details for any kind of resolution
        string GetTitle(int id);
        string GetDescription(int id);
        DateTime GetDeadline(int id);
        bool GetCompletionStatus(int id);
        DateTime GetDateCompleted(int id);
        int GetPercentageComplete(int id);
        string GetResolutionType(int id);

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

        // logic to decide what type of resolution this is
        Resolution GetResolutionFromUserInput(ResolutionChangeModel resolution);
        Resolution GetResolutionToEdit(int id, ResolutionEditModel resolution);
    }
}
