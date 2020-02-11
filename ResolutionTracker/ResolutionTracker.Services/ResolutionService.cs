using System;
using System.Collections.Generic;
using System.Linq;
using ResolutionTracker.Data;
using ResolutionTracker.Data.Models;
using ResolutionTracker.Data.Models.Common;

namespace ResolutionTracker.Services
{
    public class ResolutionService : IResolutionService
    {
        private ResolutionTrackerContext _resolutionTrackerContext;

        public ResolutionService(ResolutionTrackerContext resolutionTrackerContext)
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
                .FirstOrDefault();
        }

        public void AddResolution(Resolution newResolution)
        {
            _resolutionTrackerContext.Add(newResolution);
            _resolutionTrackerContext.SaveChanges();
        }

        public DateTime GetDateCompleted(int id)
        {
            return _resolutionTrackerContext.Resolutions
                .Where(r => r.Id.Equals(id))
                .FirstOrDefault()
                .DateCompleted;
        }

        public DateTime GetDeadline(int id)
        {
            return _resolutionTrackerContext.Resolutions
                .Where(r => r.Id.Equals(id))
                .FirstOrDefault()
                .Deadline;
        }

        public string GetDescription(int id)
        {
            return _resolutionTrackerContext.Resolutions
                .Where(r => r.Id.Equals(id))
                .FirstOrDefault()
                .Description;
        }

        // you can add the % sign within the HTML as a template
        public int GetPercentageComplete(int id)
        {
            return _resolutionTrackerContext.Resolutions
                .Where(r => r.Id.Equals(id))
                .FirstOrDefault()
                .PercentageCompleted;
        }

        public string GetTitle(int id)
        {
            return _resolutionTrackerContext.Resolutions
                .Where(r => r.Id.Equals(id))
                .FirstOrDefault()
                .Title;
        }

        public string GetResolutionType(int id)
        {
            var allResolutions = _resolutionTrackerContext.Resolutions;
            var musicResolution = allResolutions.OfType<MusicResolution>().Where(m => m.Id.Equals(id));
            var healthResolution = allResolutions.OfType<HealthResolution>().Where(h => h.Id.Equals(id));
            var codingResolution = allResolutions.OfType<CodingResolution>().Where(c => c.Id.Equals(id));
            var languageResolution = allResolutions.OfType<LanguageResolution>().Where(l => l.Id.Equals(id));

            var response = "";

            if (musicResolution.Any())
            {
                response = "Music";
            }
            else if(healthResolution.Any())
            {
                response = "Health";
            }
            else if (codingResolution.Any())
            {
                response = "Coding";
            }
            else if (languageResolution.Any())
            {
                response = "Language";
            }

            return response;
        }

        // type-specific methods for different resolutions
        public string GetMusicGenre(int id)
        {
            var musicResolutions = _resolutionTrackerContext.MusicResolutions;
            var isMusicResolution = _resolutionTrackerContext.Resolutions.OfType<MusicResolution>().Where(m => m.Id.Equals(id)).Any();
            var genreToReturn = "";

            if (isMusicResolution && !String.IsNullOrEmpty(currentMusicResolutionsGenreInDb))
            {
                genreToReturn = currentMusicResolutionsGenreInDb;
            }

            return genreToReturn;
        }

        public string GetInstrument(int id)
        {
            var musicResolutions = _resolutionTrackerContext.MusicResolutions;
            var isMusicResolution = _resolutionTrackerContext.Resolutions.OfType<MusicResolution>().Where(m => m.Id.Equals(id)).Any();

            return isMusicResolution ? musicResolutions.Where(m => m.Id.Equals(id)).FirstOrDefault().Instrument
                : "Looks like that's not a music resolution soz!";

        }

        // this was returning NULL so it made the app crash because it's supposed to return string
        public string GetHealthArea(int id)
        {
            var healthResolutions = _resolutionTrackerContext.HealthResolutions;
            var isHealthResolution = _resolutionTrackerContext.Resolutions.OfType<HealthResolution>().Where(h => h.Id.Equals(id)).Any();
            var currentHealthResolutionsHealthAreaInDb = healthResolutions.Where(h => h.Id.Equals(id)).FirstOrDefault().HealthArea;
            var healthAreaToReturn = "";

            if (isHealthResolution && !String.IsNullOrEmpty(currentHealthResolutionsHealthAreaInDb))
            {
                healthAreaToReturn = currentHealthResolutionsHealthAreaInDb;
            }

            return healthAreaToReturn;
        }

        public string GetTechnology(int id)
        {
            var codingResolutions = _resolutionTrackerContext.CodingResolutions;
            var isCodingResolution = _resolutionTrackerContext.Resolutions.OfType<CodingResolution>().Where(c => c.Id.Equals(id)).Any();

            return isCodingResolution ? codingResolutions.Where(c => c.Id.Equals(id)).FirstOrDefault().Technology
                : "I don't think that's a coding resolution sozzer";
        }

        public string GetLanguage(int id)
        {
            var languageResolutions = _resolutionTrackerContext.LanguageResolutions;
            var isLanguageResolution = _resolutionTrackerContext.Resolutions.OfType<LanguageResolution>().Where(l => l.Id.Equals(id)).Any();

            return isLanguageResolution ? languageResolutions.Where(l => l.Id.Equals(id)).FirstOrDefault().Language
                : "Il semble que ce ne soit pas une résolution sur les langues...";
        }

        public string GetSkill(int id)
        {
            var languageResolutions = _resolutionTrackerContext.LanguageResolutions;
            var isLanguageResolution = _resolutionTrackerContext.Resolutions.OfType<LanguageResolution>().Where(l => l.Id.Equals(id)).Any();

            return isLanguageResolution ? languageResolutions.Where(l => l.Id.Equals(id)).FirstOrDefault().Skill
                : "Il semble que ce ne soit pas une résolution sur les langues...";
        }

        public string GetString(int id)
        {
            throw new NotImplementedException();
        }
    }
}
