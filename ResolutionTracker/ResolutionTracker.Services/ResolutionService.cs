using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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

        // type-specific methods for different resolutions
        public string GetMusicGenre(int id)
        {
            var musicResolutions = _resolutionTrackerContext.MusicResolutions;
            var isMusicResolution = _resolutionTrackerContext.Resolutions.OfType<MusicResolution>().Where(m => m.Id.Equals(id)).Any();

            return isMusicResolution ? musicResolutions.Where(m => m.Id.Equals(id)).FirstOrDefault().MusicGenre
                : "Couldn't find a music resolution soz!";
        }

        public string GetInstrument(int id)
        {
            var musicResolutions = _resolutionTrackerContext.MusicResolutions;
            var isMusicResolution = _resolutionTrackerContext.Resolutions.OfType<MusicResolution>().Where(m => m.Id.Equals(id)).Any();

            return isMusicResolution ? musicResolutions.Where(m => m.Id.Equals(id)).FirstOrDefault().Instrument
                : "Looks like that's not a music resolution soz!";

        }

        public string GetHealthArea(int id)
        {
            var healthResolutions = _resolutionTrackerContext.HealthResolutions;
            var isHealthResolution = _resolutionTrackerContext.Resolutions.OfType<HealthResolution>().Where(h => h.Id.Equals(id)).Any();

            return isHealthResolution ? healthResolutions.Where(h => h.Id.Equals(id)).FirstOrDefault().HealthArea
                : "Looks like that's not a health resolution sozbeef!";
        }

        public string GetTechnology(int id)
        {
            throw new NotImplementedException();
        }

        public string GetLanguage(int id)
        {
            throw new NotImplementedException();
        }

        public string GetSkill(int id)
        {
            throw new NotImplementedException();
        }
    }
}
