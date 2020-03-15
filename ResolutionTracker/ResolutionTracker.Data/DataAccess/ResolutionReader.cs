using System;
using System.Collections.Generic;
using System.Linq;
using ResolutionTracker.Data.DataAccess.Common;
using ResolutionTracker.Data.Models;
using ResolutionTracker.Data.Models.Common;
using ResolutionTracker.ViewModels;
using ResolutionTracker.Utilities;
using ResolutionTracker.ViewModels.Common;

namespace ResolutionTracker.Data.DataAccess
{
    public class ResolutionReader : IResolutionReader
    {
        private ResolutionTrackerContext _resolutionTrackerContext;

        public ResolutionReader(ResolutionTrackerContext resolutionTrackerContext)
        {
            _resolutionTrackerContext = resolutionTrackerContext;
        }

        public IEnumerable<Resolution> GetAllResolutions()
        {
            return _resolutionTrackerContext.Resolutions;
        }

        public Resolution GetResolutionById(int id)
        {
            return _resolutionTrackerContext.Resolutions
                .Where(r => r.Id.Equals(id))
                .SingleOrDefault();
        }

        public bool GetCompletionStatus(int id)
        {
            return _resolutionTrackerContext.Resolutions
                .Where(r => r.Id.Equals(id))
                .SingleOrDefault()
                .IsComplete;
        }

        public DateTime GetDateCompleted(int id)
        {
            return _resolutionTrackerContext.Resolutions
                .Where(r => r.Id.Equals(id))
                .SingleOrDefault()
                .DateCompleted;
        }

        public DateTime GetDeadline(int id)
        {
            return _resolutionTrackerContext.Resolutions
                .Where(r => r.Id.Equals(id))
                .SingleOrDefault()
                .Deadline;
        }

        public string GetDescription(int id)
        {
            return _resolutionTrackerContext.Resolutions
                .Where(r => r.Id.Equals(id))
                .SingleOrDefault()
                .Description;
        }

        // you can add the % sign within the HTML as a template
        public int GetPercentageComplete(int id)
        {
            return _resolutionTrackerContext.Resolutions
                .Where(r => r.Id.Equals(id))
                .SingleOrDefault()
                .PercentageCompleted;
        }

        public string GetTitle(int id)
        {
            return _resolutionTrackerContext.Resolutions
                .Where(r => r.Id.Equals(id))
                .SingleOrDefault()
                .Title;
        }

        // specific types of resolution
        public IEnumerable<MusicResolution> GetMusicResolutions()
        {
            return _resolutionTrackerContext.MusicResolutions;
        }

        public IEnumerable<HealthResolution> GetHealthResolutions()
        {
            return _resolutionTrackerContext.HealthResolutions;
        }

        public IEnumerable<CodingResolution> GetCodingResolutions()
        {
            return _resolutionTrackerContext.CodingResolutions;
        }

        public IEnumerable<LanguageResolution> GetLanguageResolutions()
        {
            return _resolutionTrackerContext.LanguageResolutions;
        }

        // type-specific methods for different resolutions
        public string GetMusicGenre(int id)
        {
            var musicResolutions = GetMusicResolutions();
            var isMusicResolution = _resolutionTrackerContext.Resolutions.OfType<MusicResolution>().Where(m => m.Id.Equals(id)).Any();
            var currentGenreValue = isMusicResolution ? musicResolutions.Where(m => m.Id.Equals(id)).SingleOrDefault().MusicGenre
                     : "No genre needed";

            var newGenreValue = String.IsNullOrEmpty(currentGenreValue) ? "No genre" : currentGenreValue;
            return newGenreValue;
        }

        public string GetInstrument(int id)
        {
            var musicResolutions = GetMusicResolutions();
            var isMusicResolution = _resolutionTrackerContext.Resolutions.OfType<MusicResolution>().Where(m => m.Id.Equals(id)).Any();
            var currentInstrumentValue = isMusicResolution ? musicResolutions.Where(m => m.Id.Equals(id)).SingleOrDefault().Instrument
                : "No instrument needed";

            // what do you do if musicResolutions.Where(m => m.Id.Equals(id)).FirstOrDefault().Instrument is NULL?
            var newInstrumentValue = String.IsNullOrEmpty(currentInstrumentValue) ? "No instrument" : currentInstrumentValue;
            return newInstrumentValue;
        }

        // this was returning NULL so it made the app crash because it's supposed to return string
        public string GetHealthArea(int id)
        {
            var healthResolutions = GetHealthResolutions();
            var isHealthResolution = _resolutionTrackerContext.Resolutions.OfType<HealthResolution>().Where(h => h.Id.Equals(id)).Any();
            var currentHealthAreaValue = isHealthResolution ? healthResolutions.Where(c => c.Id.Equals(id)).SingleOrDefault().HealthArea
                : "No health area needed";

            var newHealthAreaValue = String.IsNullOrEmpty(currentHealthAreaValue) ? "No health area" : currentHealthAreaValue;
            return newHealthAreaValue;
        }

        public string GetTechnology(int id)
        {
            var codingResolutions = GetCodingResolutions();
            var isCodingResolution = _resolutionTrackerContext.Resolutions.OfType<CodingResolution>().Where(c => c.Id.Equals(id)).Any();
            var currentTechnologyValue = isCodingResolution ? codingResolutions.Where(c => c.Id.Equals(id)).SingleOrDefault().Technology
                : "No technology needed";

            var newTechnologyValue = String.IsNullOrEmpty(currentTechnologyValue) ? "No technology" : currentTechnologyValue;
            return newTechnologyValue;
        }

        public string GetLanguage(int id)
        {
            var languageResolutions = GetLanguageResolutions();
            var isLanguageResolution = _resolutionTrackerContext.Resolutions.OfType<LanguageResolution>().Where(l => l.Id.Equals(id)).Any();
            var currentLanguageValue = isLanguageResolution ? languageResolutions.Where(c => c.Id.Equals(id)).SingleOrDefault().Language
                : "Aucune langue requise";

            var newLanguageValue = String.IsNullOrEmpty(currentLanguageValue) ? "Il n'y a aucune langue à montrer" : currentLanguageValue;
            return newLanguageValue;
        }

        public string GetSkill(int id)
        {
            var languageResolutions = GetLanguageResolutions();
            var isLanguageResolution = _resolutionTrackerContext.Resolutions.OfType<LanguageResolution>().Where(l => l.Id.Equals(id)).Any();
            var currentSkillValue = isLanguageResolution ? languageResolutions.Where(c => c.Id.Equals(id)).SingleOrDefault().Skill
                : "Aucune compétence requise";

            var newSkillValue = String.IsNullOrEmpty(currentSkillValue) ? "Il n'y a aucune compétence à montrer" : currentSkillValue;
            return newSkillValue;
        }
    }
}
