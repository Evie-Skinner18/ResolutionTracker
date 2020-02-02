using NUnit.Framework;
using ResolutionTracker.Data.Models.Common;

namespace ResolutionTracker.Tests
{
    public class ResolutionServiceTests
    {
        IResolutionService _fakeResolutionService;

        [SetUp]
        public void Setup()
        {
            _fakeResolutionService = new FakeResolutionService();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}