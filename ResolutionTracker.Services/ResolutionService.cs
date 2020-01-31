using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ResolutionTracker.Data;
using ResolutionTracker.Data.Common;

namespace ResolutionTracker.Services
{
    public class ResolutionService : IResolutionService
    {
        private ResolutionTrackerContext _resolutionTrackerContext;

        public ResolutionService(ResolutionTrackerContext resolutionTrackerContext)
        {
            _resolutionTrackerContext = resolutionTrackerContext;
        }

        public void AddResolution(Resolution newResolution)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Resolution> GetAllResolutions()
        {
            throw new NotImplementedException();
        }

        public DateTime GetDateCompleted(int id)
        {
            throw new NotImplementedException();
        }

        public DateTime GetDeadline(int id)
        {
            throw new NotImplementedException();
        }

        public string GetDescription(int id)
        {
            throw new NotImplementedException();
        }

        public int GetPercentageComplete(int id)
        {
            throw new NotImplementedException();
        }

        public Resolution GetResolutionById(int id)
        {
            throw new NotImplementedException();
        }

        public string GetTitle(int id)
        {
            throw new NotImplementedException();
        }
    }
}
