using System;
using ResolutionTracker.Data.DataAccess.Common;

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
    }
}
