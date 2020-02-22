using System;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using ResolutionTracker.Data.Models;
using ResolutionTracker.Data.Models.Common;
using ResolutionTracker.Services.Common;
using ResolutionTracker.ViewModels;

namespace ResolutionTracker.Controllers
{
    public class ResolutionController : Controller
    {
        private IResolutionReaderService _resolutionReaderService;
        private IResolutionWriterService _resolutionWriterService;

        public ResolutionController(IResolutionReaderService resolutionReaderService, IResolutionWriterService resolutionWriterService)
        {
            _resolutionReaderService = resolutionReaderService;
            _resolutionWriterService = resolutionWriterService;
        }

        // root route
        [HttpGet]
        public IActionResult Index()
        {
            // first step is to tell our service to grab all the resolutions from the DB
            var allResolutions = _resolutionReaderService.GetAllResolutions().ToList();

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
        [HttpGet]
        public IActionResult Detail(int id)
        {
            var currentResolution = _resolutionReaderService.GetResolutionById(id);
            var currentResolutionType = _resolutionReaderService.GetResolutionType(id);
            var currentResolutionHealthArea = _resolutionReaderService.GetHealthArea(id);
            

            var resolutionDetailObject = new ResolutionDetailModel()
            {
                ResolutionId = currentResolution.Id.ToString(),
                ResolutionTitle = currentResolution.Title,
                ResolutionDescription = currentResolution.Description,
                ResolutionDeadline = currentResolution.Deadline.ToShortDateString(),
                ResolutionType = _resolutionReaderService.GetResolutionType(id),
                PercentageCompletion = currentResolution.PercentageCompleted.ToString(),
                PercentageLeft = (100 - currentResolution.PercentageCompleted).ToString(),
                DateCompleted = currentResolution.DateCompleted.ToShortDateString(),
                MusicGenre = _resolutionReaderService.GetMusicGenre(id),
                MusicalInstrument = _resolutionReaderService.GetInstrument(id),
                HealthArea = _resolutionReaderService.GetHealthArea(id).ToLower(),
                CodingTechnology = _resolutionReaderService.GetTechnology(id),
                Language = _resolutionReaderService.GetLanguage(id),
                LanguageSkill = _resolutionReaderService.GetSkill(id).ToLower()
            };

            return View(resolutionDetailObject);
        }

        // GET returns the default Create view which is the form
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //   POST (how to protect against over posting attack?)
        // also make sure you sanitise the user inputs
        // to-do: add calendar to date input
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ResolutionCreateModel newResolution)
        {
            if (ModelState.IsValid)
            {
                var resolutionToAdd = _resolutionReaderService.GetResolutionFromUserInput(newResolution);
                _resolutionWriterService.AddResolution(resolutionToAdd);
                return RedirectToAction("Index");
            }
            else
            {
                return View(newResolution);
            }
        }

        // update
        // GET returns the default Edit view which is again the form
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return new BadRequestResult();
            }

            var resolutionToEdit = _resolutionReaderService.GetResolutionById(id);
            return resolutionToEdit.Equals(null) ? View(new NotFoundResult()) : View(resolutionToEdit);
        }

        // UPDATE corresponds to Put. Put means you submit the whole object again when you update; Patch means you submit only certain deetz
        // for now keeping this as a ResolutionCreateModel to re-use that
        [HttpPut]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ResolutionCreateModel resolutionToEdit)
        {
            // finish this Put method

        }







        //delete routes
    }
}
