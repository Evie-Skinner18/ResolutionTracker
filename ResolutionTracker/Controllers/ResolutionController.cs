﻿using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ResolutionTracker.Data.Models.Common;

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

            // then we pass this list of view objects to the view
            return View();
        }
    }
}
