using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ResolutionTracker.Data;
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
            throw new NotImplementedException();
        }

        public int GetPercentageComplete(int id)
        {
            throw new NotImplementedException();
        }

        public string GetTitle(int id)
        {
            throw new NotImplementedException();
        }

        // type-specific methods for different resolutions
        public string GetMusicGenre(int id)
        {
            throw new NotImplementedException();
        }

        public string GetInstrument(int id)
        {
            throw new NotImplementedException();
        }

        public string GetHealthArea(int id)
        {
            throw new NotImplementedException();
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
