using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ResolutionTracker.Data.Models;
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

        // GET returns the default Create view which is the form
        public IActionResult Create()
        {
            return View();
        }

        //   POST (how to protect against over posting attack?)
        // also make sure you sanitise the user inputs
        // this method is far too long
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ResolutionCreateModel newResolution)
        {

            // to-do: add calendar to date input
            // chop off the % sign that the user will input
            // make sure the object being passed is actually there. Right now it's NULL
            if (ModelState.IsValid && newResolution.ResolutionType.ToLower().Equals("music"))
            {
                var musicResolutionForDatabase = new MusicResolution()
                {
                    Title = newResolution.ResolutionTitle,
                    Description = newResolution.ResolutionDescription,
                    Deadline = DateTime.Parse(newResolution.ResolutionDeadline),
                    PercentageCompleted = Int32.Parse(newResolution.PercentageCompletion),
                    MusicGenre = newResolution.MusicGenre,
                    Instrument = newResolution.MusicalInstrument
                };

                _resolutionService.AddResolution(musicResolutionForDatabase);
                return RedirectToAction("Index");        
            }
            else if (ModelState.IsValid && newResolution.ResolutionType.ToLower().Equals("health"))
            {
                var healthResolutionForDatabase = new HealthResolution()
                {
                    Title = newResolution.ResolutionTitle,
                    Description = newResolution.ResolutionDescription,
                    Deadline = DateTime.Parse(newResolution.ResolutionDeadline),
                    PercentageCompleted = Int32.Parse(newResolution.PercentageCompletion),
                    HealthArea = newResolution.HealthArea
                };

                _resolutionService.AddResolution(healthResolutionForDatabase);
                return RedirectToAction("Index");
            }
            else if (ModelState.IsValid && newResolution.ResolutionType.ToLower().Equals("coding"))
            {
                var codingResolutionForDatabase = new CodingResolution()
                {
                    Title = newResolution.ResolutionTitle,
                    Description = newResolution.ResolutionDescription,
                    Deadline = DateTime.Parse(newResolution.ResolutionDeadline),
                    PercentageCompleted = Int32.Parse(newResolution.PercentageCompletion),
                    Technology = newResolution.CodingTechnology
                };

                _resolutionService.AddResolution(codingResolutionForDatabase);
                return RedirectToAction("Index");
            }
            else if (ModelState.IsValid && newResolution.ResolutionType.ToLower().Equals("language"))
            {
                var languageResolutionForDatabase = new LanguageResolution()
                {
                    Title = newResolution.ResolutionTitle,
                    Description = newResolution.ResolutionDescription,
                    Deadline = DateTime.Parse(newResolution.ResolutionDeadline),
                    PercentageCompleted = Int32.Parse(newResolution.PercentageCompletion),
                    Language = newResolution.Language,
                    Skill = newResolution.LanguageSkill
                };

                _resolutionService.AddResolution(languageResolutionForDatabase);
                return RedirectToAction("Index");
            }
            else
            {
                return View(newResolution);
            }
        }

        

        // update and delete routes
    }
}
