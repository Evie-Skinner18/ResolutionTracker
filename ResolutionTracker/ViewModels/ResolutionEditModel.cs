using ResolutionTracker.ViewModels.Common;

namespace ResolutionTracker.ViewModels
{
    public class ResolutionEditModel : ResolutionChangeModel
    {
        public bool ResolutionIsComplete { get; set; }

        public string ResolutionDateCompleted { get; set; }
    }
}
