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
        private IResolutionService _resolutionService;

        public ResolutionController(IResolutionService resolutionService)
        {
            _resolutionService = resolutionService;
        }

        // root route
        [HttpGet]
        public IActionResult Index()
        {
            // have the service get what we need
            var resolutionIndexObject = _resolutionService.GetResolutionIndexObject();
            // then we pass this ResolutionIndexModel to the view
            return View(resolutionIndexObject);
        }

        // SHOW route
        [HttpGet]
        public IActionResult Detail(int id)
        {
            var currentResolutionDetailObject = _resolutionService.GetResolutionDetailObject(id);           
            return View(currentResolutionDetailObject);
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
        public IActionResult Create(ResolutionCreateModel newViewResolution)
        {
            if (ModelState.IsValid)
            {
                var resolutionToAdd = _resolutionService.GetResolutionFromUserInput(newViewResolution);
                _resolutionService.CreateResolution(resolutionToAdd);
                return RedirectToAction("Index");
            }
            else
            {
                return View(newViewResolution);
            }
        }

        // update
        // GET returns the default Edit view which is again the form
        [HttpGet]
        public IActionResult Edit(int id)
        {
            // get resolution to edit
            var viewResolutionToEdit = _resolutionService.GetResolutionEditObject(id);

            return viewResolutionToEdit == null ? View(new NotFoundResult()) : View(viewResolutionToEdit);
        }

        // UPDATE corresponds to Put. Put means you submit the whole object again when you update; Patch means you submit only certain deetz
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ResolutionEditModel viewResolutionToEdit)
        {
            // finish this Put method
            if (ModelState.IsValid)
            {
                //reassign the values of the resolution's properties with the values we've received
                // in the view model
                var resolutionToUpdate = _resolutionService.GetResolutionToEdit(id, viewResolutionToEdit);
                _resolutionService.EditResolution(resolutionToUpdate);
                return RedirectToAction("Index");
            }
            else
            {
                return View(viewResolutionToEdit);
            }
        }







        //delete routes
    }
}
