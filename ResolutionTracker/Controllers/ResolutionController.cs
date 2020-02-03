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

        public IActionResult Index()
        {
            return View();
        }
    }
}
