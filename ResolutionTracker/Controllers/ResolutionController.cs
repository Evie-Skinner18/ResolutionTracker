using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ResolutionTracker.Data.Models.Common;
using ResolutionTracker.ViewModels;

namespace ResolutionTracker.Controllers
{
    public class ResolutionController : Controller
    {
        private IResolutionService _resolutionService;

        public ResolutionController(IResolutionService resolutionService)
        {
            _resolutionService = resolutionService;
        }

        // root route
        public IActionResult Index()
        {
            // first step is to tell our service to grab all the resolutions from the DB
            var allResolutions = _resolutionService.GetAllResolutions().ToList();

            // next step is to translate each resolution object into an instance of the view model
            var allResolutionViewObjects = allResolutions
                .Select(r => new ResolutionIndexListingModel()
                {
                    ResolutionId = r.Id.ToString(),
                    ResolutionTitle = r.Title
                });

            // put his list of view objects inside an instance of ResolutionIndexModel
            var resolutionIndexObject = new ResolutionIndexModel() { Resolutions = allResolutionViewObjects };

            // then we pass this ResolutionIndexModel to the view
            return View(resolutionIndexObject);
        }

        // SHOW route
        public IActionResult Detail(int id)
        {
            var currentResolution = _resolutionService.GetResolutionById(id);

            var resolutionDetailObject = new ResolutionDetailModel()
            {
                ResolutionId = currentResolution.Id.ToString(),
                ResolutionTitle = currentResolution.Title,
                ResolutionDescription = currentResolution.Description,
                ResolutionDeadline = currentResolution.Deadline.ToShortDateString(),
                ResolutionType = _resolutionService.GetResolutionType(id),
                PercentageCompletion = currentResolution.PercentageCompleted.ToString(),
                PercentageLeft = (100 - currentResolution.PercentageCompleted).ToString(),
                DateCompleted = currentResolution.DateCompleted.ToShortDateString(),
                MusicGenre = _resolutionService.GetMusicGenre(id),
                MusicalInstrument = _resolutionService.GetInstrument(id),
                HealthArea = _resolutionService.GetHealthArea(id).ToLower(),
                CodingTechnology = _resolutionService.GetTechnology(id),
                Language = _resolutionService.GetLanguage(id),
                LanguageSkill = _resolutionService.GetSkill(id).ToLower()
            };

            return View(resolutionDetailObject);
        }

        // NEW routes for adding new resolution
        // not very DRY because I've got different types of resolutions inheriting from Resolution. So can't have one catch all Create() method
        // different resolutions have different properties. Maybe inheriting was wrong way to go...
        public IActionResult CreateMusicResolution()
        {

        }

        public IActionResult CreateHealthResolution()
        {

        }

        public IActionResult CreateCodingResolution()
        {

        }

        public IActionResult CreateLanguageResolution()
        {

        }

        // update and delete routes
    }
}
