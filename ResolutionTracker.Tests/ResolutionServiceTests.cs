using NUnit.Framework;
using ResolutionTracker.Data.Models.Common;
using ResolutionTracker.Services.Common;

namespace ResolutionTracker.Tests
{
    public class ResolutionServiceTests
    {
        IResolutionReaderService _fakeResolutionReaderService;

        [SetUp]
        public void Setup()
        {
            _fakeResolutionReaderService = new FakeResolutionReaderService();
        }

        [Test]
        public void Test1()
        {
            Assert.That("Hello".Equals("Hello"));
        }
    }
}