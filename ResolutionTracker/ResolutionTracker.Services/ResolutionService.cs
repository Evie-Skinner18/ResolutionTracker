using System;
using System.Linq;
using ResolutionTracker.Data.DataAccess.Common;
using ResolutionTracker.Data.Models;
using ResolutionTracker.ViewModels;

namespace ResolutionTracker.Services
{
    public class ResolutionService
    {
        private IResolutionReader _resolutionReader;
        private IResolutionWriter _resolutionWriter;

        public ResolutionService(IResolutionReader resolutionReader, IResolutionWriter resolutionWriter)
        {
            _resolutionReader = resolutionReader;
            _resolutionWriter = resolutionWriter;
        }

        public ResolutionIndexModel GetResolutionIndexObject()
        {
            // first step is to tell our reader to grab all the resolutions from the DB
            var allResolutions = _resolutionReader.GetAllResolutions().ToList();

            // next step is to translate each resolution object into an instance of the view model
            var allResolutionViewObjects = allResolutions
                .Select(r => new ResolutionIndexListingModel()
                {
                    ResolutionId = r.Id.ToString(),
                    ResolutionTitle = r.Title
                });

            // put this list of view objects inside an instance of ResolutionIndexModel
            var resolutionIndexObject = new ResolutionIndexModel() { Resolutions = allResolutionViewObjects };
            return resolutionIndexObject;
        }

        public ResolutionDetailModel GetResolutionDetailObject(int id)
        {
            var currentResolution = _resolutionReader.GetResolutionById(id);

            var resolutionDetailObject = new ResolutionDetailModel()
            {
                ResolutionId = currentResolution.Id.ToString(),
                ResolutionTitle = currentResolution.Title,
                ResolutionDescription = currentResolution.Description,
                ResolutionDeadline = currentResolution.Deadline.ToShortDateString(),
                ResolutionType = GetResolutionType(id),
                PercentageCompletion = currentResolution.PercentageCompleted.ToString(),
                PercentageLeft = (100 - currentResolution.PercentageCompleted).ToString(),
                DateCompleted = currentResolution.DateCompleted.ToShortDateString(),
                MusicGenre = _resolutionReader.GetMusicGenre(id),
                MusicalInstrument = _resolutionReader.GetInstrument(id),
                HealthArea = _resolutionReader.GetHealthArea(id).ToLower(),
                CodingTechnology = _resolutionReader.GetTechnology(id),
                Language = _resolutionReader.GetLanguage(id),
                LanguageSkill = _resolutionReader.GetSkill(id).ToLower()
            };

            return resolutionDetailObject;
        }

        public string GetResolutionType(int id)
        {
            // this allResolutions query is fine wile the dataset is small. For massive ones do not do this
            var allResolutions = _resolutionReader.GetAllResolutions();
            var musicResolution = allResolutions.OfType<MusicResolution>().Where(m => m.Id.Equals(id));
            var healthResolution = allResolutions.OfType<HealthResolution>().Where(h => h.Id.Equals(id));
            var codingResolution = allResolutions.OfType<CodingResolution>().Where(c => c.Id.Equals(id));
            var languageResolution = allResolutions.OfType<LanguageResolution>().Where(l => l.Id.Equals(id));

            var response = "";

            if (musicResolution.Any())
            {
                response = "Music";
            }
            else if (healthResolution.Any())
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
    }
}
