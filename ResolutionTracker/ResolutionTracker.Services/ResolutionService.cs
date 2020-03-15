using System;
using System.Linq;
using ResolutionTracker.Data.DataAccess.Common;
using ResolutionTracker.Data.Models;
using ResolutionTracker.Data.Models.Common;
using ResolutionTracker.Services.Common;
using ResolutionTracker.Utilities;
using ResolutionTracker.ViewModels;
using ResolutionTracker.ViewModels.Common;

namespace ResolutionTracker.Services
{
    public class ResolutionService : IResolutionService
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
            var allResolutions = _resolutionReader.GetAllResolutions();
            var resolutionToEdit = _resolutionReader.GetResolutionById(id);
            var musicResolutions = _resolutionReader.GetMusicResolutions().Where(m => m.Id.Equals(id));
            var healthResolutions = _resolutionReader.GetHealthResolutions().Where(h => h.Id.Equals(id));
            var codingResolutions = _resolutionReader.GetCodingResolutions().Where(c => c.Id.Equals(id));
            var languageResolutions = _resolutionReader.GetLanguageResolutions().Where(l => l.Id.Equals(id));

            var percentageWithoutPercentageSign = viewResolution.PercentageCompletion.RemovePercentageSign();
            var dateCompleted = viewResolution.ResolutionIsComplete ? DateTime.Parse(viewResolution.ResolutionDateCompleted) : resolutionToEdit.DateCompleted;

            // general properties that we can update regardless of specific type
            resolutionToEdit.Title = viewResolution.ResolutionTitle;
            resolutionToEdit.Description = viewResolution.ResolutionDescription;
            resolutionToEdit.Deadline = DateTime.Parse(viewResolution.ResolutionDeadline);
            resolutionToEdit.DateCompleted = dateCompleted;
            resolutionToEdit.PercentageCompleted = Int32.Parse(percentageWithoutPercentageSign);

            // abstract this into separate method
            if (musicResolutions.Any())
            {
                var musicResolutionToEdit = musicResolutions.Where(m => m.Id.Equals(id)).SingleOrDefault();
                musicResolutionToEdit.MusicGenre = viewResolution.MusicGenre;
                musicResolutionToEdit.Instrument = viewResolution.MusicalInstrument;
            }
            else if (healthResolutions.Any())
            {
                var healthResolutionToEdit = healthResolutions.Where(h => h.Id.Equals(id)).SingleOrDefault();
                healthResolutionToEdit.HealthArea = viewResolution.HealthArea;
            }
            else if (codingResolutions.Any())
            {
                var codingResolutionToEdit = codingResolutions.Where(c => c.Id.Equals(id)).SingleOrDefault();
                codingResolutionToEdit.Technology = viewResolution.CodingTechnology;
            }
            else
            {
                var languageResolutionToEdit = languageResolutions.Where(l => l.Id.Equals(id)).SingleOrDefault();
                languageResolutionToEdit.Language = viewResolution.Language;
                languageResolutionToEdit.Skill = viewResolution.LanguageSkill;
            }

            return resolutionToEdit;
        }

        // methods that just call the writer
        public void CreateResolution(Resolution resolution)
        {
            if (resolution != null)
            {
                _resolutionWriter.AddResolution(resolution);
            }
            else
            {
                throw new ArgumentNullException("The resolution you're trying to add is null :<");
            }
        }

        public void EditResolution(Resolution resolution)
        {
            if(resolution != null)
            {
                _resolutionWriter.UpdateResolution(resolution);
            }
            else
            {
                throw new ArgumentNullException("The resolution you're trying to update is null :<");
            }
        }

        // map a resolution to its view model equivalent
        public ResolutionEditModel GetResolutionEditObject(int id)
        {
            var resolutionToEdit = _resolutionReader.GetResolutionById(id);

            var viewResolutionToEdit = new ResolutionEditModel()
            {
                ResolutionId = resolutionToEdit.Id.ToString(),
                ResolutionTitle = resolutionToEdit.Title,
                ResolutionDescription = resolutionToEdit.Description,
                ResolutionDeadline = resolutionToEdit.Deadline.ToString(),
                ResolutionType = GetResolutionType(id),
                PercentageCompletion = resolutionToEdit.PercentageCompleted.ToString(),
                MusicGenre = _resolutionReader.GetMusicGenre(id),
                MusicalInstrument = _resolutionReader.GetInstrument(id),
                HealthArea = _resolutionReader.GetHealthArea(id),
                CodingTechnology = _resolutionReader.GetTechnology(id),
                Language = _resolutionReader.GetLanguage(id),
                LanguageSkill = _resolutionReader.GetSkill(id)
            };

            return viewResolutionToEdit;
        }
    }
}
