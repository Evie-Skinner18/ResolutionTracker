using System;
using System.Collections.Generic;
using System.Linq;
using ResolutionTracker.Services.Common;
using ResolutionTracker.Data;
using ResolutionTracker.Data.Models;
using ResolutionTracker.Data.Models.Common;
using ResolutionTracker.ViewModels;
using ResolutionTracker.Utilities;
using ResolutionTracker.ViewModels.Common;

namespace ResolutionTracker.Services
{
    public class ResolutionReaderService : IResolutionReaderService
    {
        private ResolutionTrackerContext _resolutionTrackerContext;

        public ResolutionReaderService(ResolutionTrackerContext resolutionTrackerContext)
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

        public bool GetCompletionStatus(int id)
        {
            return _resolutionTrackerContext.Resolutions
                .Where(r => r.Id.Equals(id))
                .FirstOrDefault()
                .IsComplete;
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
            var currentGenreValue = isMusicResolution ? musicResolutions.Where(m => m.Id.Equals(id)).FirstOrDefault().MusicGenre
                     : "No genre needed";

            var newGenreValue = String.IsNullOrEmpty(currentGenreValue) ? "No genre" : currentGenreValue;
            return newGenreValue;
        }

        public string GetInstrument(int id)
        {
            var musicResolutions = _resolutionTrackerContext.MusicResolutions;
            var isMusicResolution = _resolutionTrackerContext.Resolutions.OfType<MusicResolution>().Where(m => m.Id.Equals(id)).Any();
            var currentInstrumentValue = isMusicResolution ? musicResolutions.Where(m => m.Id.Equals(id)).FirstOrDefault().Instrument
                : "No instrument needed";

            // what do you do if musicResolutions.Where(m => m.Id.Equals(id)).FirstOrDefault().Instrument is NULL?
            var newInstrumentValue = String.IsNullOrEmpty(currentInstrumentValue) ? "No instrument" : currentInstrumentValue;
            return newInstrumentValue;
        }

        // this was returning NULL so it made the app crash because it's supposed to return string
        public string GetHealthArea(int id)
        {
            var healthResolutions = _resolutionTrackerContext.HealthResolutions;
            var isHealthResolution = _resolutionTrackerContext.Resolutions.OfType<HealthResolution>().Where(h => h.Id.Equals(id)).Any();
            var currentHealthAreaValue = isHealthResolution ? healthResolutions.Where(c => c.Id.Equals(id)).FirstOrDefault().HealthArea
                : "No health area needed";

            var newHealthAreaValue = String.IsNullOrEmpty(currentHealthAreaValue) ? "No health area" : currentHealthAreaValue;
            return newHealthAreaValue;
        }

        public string GetTechnology(int id)
        {
            var codingResolutions = _resolutionTrackerContext.CodingResolutions;
            var isCodingResolution = _resolutionTrackerContext.Resolutions.OfType<CodingResolution>().Where(c => c.Id.Equals(id)).Any();
            var currentTechnologyValue = isCodingResolution ? codingResolutions.Where(c => c.Id.Equals(id)).FirstOrDefault().Technology
                : "No technology needed";

            var newTechnologyValue = String.IsNullOrEmpty(currentTechnologyValue) ? "No technology" : currentTechnologyValue;
            return newTechnologyValue;
        }

        public string GetLanguage(int id)
        {
            var languageResolutions = _resolutionTrackerContext.LanguageResolutions;
            var isLanguageResolution = _resolutionTrackerContext.Resolutions.OfType<LanguageResolution>().Where(l => l.Id.Equals(id)).Any();
            var currentLanguageValue = isLanguageResolution ? languageResolutions.Where(c => c.Id.Equals(id)).FirstOrDefault().Language
                : "Aucune langue requise";

            var newLanguageValue = String.IsNullOrEmpty(currentLanguageValue) ? "Il n'y a aucune langue à montrer" : currentLanguageValue;
            return newLanguageValue;
        }

        public string GetSkill(int id)
        {
            var languageResolutions = _resolutionTrackerContext.LanguageResolutions;
            var isLanguageResolution = _resolutionTrackerContext.Resolutions.OfType<LanguageResolution>().Where(l => l.Id.Equals(id)).Any();
            var currentSkillValue = isLanguageResolution ? languageResolutions.Where(c => c.Id.Equals(id)).FirstOrDefault().Skill
                : "Aucune compétence requise";

            var newSkillValue = String.IsNullOrEmpty(currentSkillValue) ? "Il n'y a aucune compétence à montrer" : currentSkillValue;
            return newSkillValue;
        }

        // should these next two be in the reader or writer?

        // when a user fills out the CREATE form, we need to pick which kind of resolution to return to the view based on
        // the type that the user puts in. It maps the ResolutionCreateModel given to it to a Resolution that the DB can take
        public Resolution GetResolutionFromUserInput(ResolutionChangeModel viewResolution)
        {
            Resolution resolutionToAdd;
            var resolutionType = viewResolution.ResolutionType.ToLower();
            var percentageWithoutPercentageSign = viewResolution.PercentageCompletion.RemovePercentageSign();

            switch (resolutionType)
            {
                case "music":
                    resolutionToAdd = new MusicResolution()
                    {
                        Title = viewResolution.ResolutionTitle,
                        Description = viewResolution.ResolutionDescription,
                        Deadline = DateTime.Parse(viewResolution.ResolutionDeadline),
                        PercentageCompleted = Int32.Parse(percentageWithoutPercentageSign),
                        MusicGenre = viewResolution.MusicGenre,
                        Instrument = viewResolution.MusicalInstrument
                    };
                    break;
                case "health":
                    resolutionToAdd = new HealthResolution()
                    {
                        Title = viewResolution.ResolutionTitle,
                        Description = viewResolution.ResolutionDescription,
                        Deadline = DateTime.Parse(viewResolution.ResolutionDeadline),
                        PercentageCompleted = Int32.Parse(percentageWithoutPercentageSign),
                        HealthArea = viewResolution.HealthArea
                    };
                    break;
                case "coding":
                    resolutionToAdd = new CodingResolution()
                    {
                        Title = viewResolution.ResolutionTitle,
                        Description = viewResolution.ResolutionDescription,
                        Deadline = DateTime.Parse(viewResolution.ResolutionDeadline),
                        PercentageCompleted = Int32.Parse(percentageWithoutPercentageSign),
                        Technology = viewResolution.CodingTechnology
                    };
                    break;
                case "language":
                    resolutionToAdd = new LanguageResolution()
                    {
                        Title = viewResolution.ResolutionTitle,
                        Description = viewResolution.ResolutionDescription,
                        Deadline = DateTime.Parse(viewResolution.ResolutionDeadline),
                        PercentageCompleted = Int32.Parse(percentageWithoutPercentageSign),
                        Language = viewResolution.Language,
                        Skill = viewResolution.LanguageSkill
                    };
                    break;
                default:
                    resolutionToAdd = new Resolution()
                    {
                        Title = viewResolution.ResolutionTitle,
                        Description = viewResolution.ResolutionDescription,
                        Deadline = DateTime.Parse(viewResolution.ResolutionDeadline),
                        PercentageCompleted = Int32.Parse(percentageWithoutPercentageSign),
                    };
                    break;
            }

            return resolutionToAdd;
        }

        // get this working first and refactor later
        public Resolution GetResolutionToEdit(int id, ResolutionEditModel viewResolution)
        {
            var allResolutions = _resolutionTrackerContext.Resolutions;
            var resolutionToEdit = GetResolutionById(id);
            var musicResolutions = allResolutions.OfType<MusicResolution>().Where(m => m.Id.Equals(id));
            var healthResolutions = allResolutions.OfType<HealthResolution>().Where(h => h.Id.Equals(id));
            var codingResolutions = allResolutions.OfType<CodingResolution>().Where(c => c.Id.Equals(id));
            var languageResolutions = allResolutions.OfType<LanguageResolution>().Where(l => l.Id.Equals(id));

            var percentageWithoutPercentageSign = viewResolution.PercentageCompletion.RemovePercentageSign();
            var dateCompleted = viewResolution.ResolutionIsComplete ? DateTime.Parse(viewResolution.ResolutionDateCompleted) : resolutionToEdit.DateCompleted;

            // general properties that we can update regardless of specific type
            resolutionToEdit.Title = viewResolution.ResolutionTitle;
            resolutionToEdit.Description = viewResolution.ResolutionDescription;
            resolutionToEdit.Deadline = DateTime.Parse(viewResolution.ResolutionDeadline);
            resolutionToEdit.DateCompleted = dateCompleted;
            resolutionToEdit.PercentageCompleted = Int32.Parse(percentageWithoutPercentageSign);

            if (musicResolutions.Any())
            {
                var musicResolutionToEdit = musicResolutions.Where(m => m.Id.Equals(id)).FirstOrDefault();
                musicResolutionToEdit.MusicGenre = viewResolution.MusicGenre;
                musicResolutionToEdit.Instrument = viewResolution.MusicalInstrument;
            }
            else if (healthResolutions.Any())
            {
                var healthResolutionToEdit = healthResolutions.Where(h => h.Id.Equals(id)).FirstOrDefault();
                healthResolutionToEdit.HealthArea = viewResolution.HealthArea;
            }
            else if (codingResolutions.Any())
            {
                var codingResolutionToEdit = codingResolutions.Where(c => c.Id.Equals(id)).FirstOrDefault();
                codingResolutionToEdit.Technology = viewResolution.CodingTechnology;
            }
            else
            {
                var languageResolutionToEdit = languageResolutions.Where(l => l.Id.Equals(id)).FirstOrDefault();
                languageResolutionToEdit.Language = viewResolution.Language;
                languageResolutionToEdit.Skill = viewResolution.LanguageSkill;
            }

            return resolutionToEdit;
        }
    }
}
