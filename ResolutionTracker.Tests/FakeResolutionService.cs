using System;
using System.Collections.Generic;
using ResolutionTracker.Data.Models.Common;
using ResolutionTracker.Services.Common;
using ResolutionTracker.ViewModels;

namespace ResolutionTracker.Tests
{
    public class FakeResolutionReaderService : IResolutionReaderService
    {
     
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

        public string GetHealthArea(int id)
        {
            throw new NotImplementedException();
        }

        public string GetInstrument(int id)
        {
            throw new NotImplementedException();
        }

        public string GetLanguage(int id)
        {
            throw new NotImplementedException();
        }

        public string GetMusicGenre(int id)
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

        public Resolution GetResolutionFromUserInput(ResolutionCreateModel resolution)
        {
            throw new NotImplementedException();
        }

        public string GetResolutionType(int id)
        {
            throw new NotImplementedException();
        }

        public string GetSkill(int id)
        {
            throw new NotImplementedException();
        }

        public string GetTechnology(int id)
        {
            throw new NotImplementedException();
        }

        public string GetTitle(int id)
        {
            throw new NotImplementedException();
        }
    }
}