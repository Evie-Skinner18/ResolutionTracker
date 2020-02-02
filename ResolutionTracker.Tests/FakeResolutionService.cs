using System;
using System.Collections.Generic;
using ResolutionTracker.Data.Models.Common;

namespace ResolutionTracker.Tests
{
    public class FakeResolutionService : IResolutionService
    {
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