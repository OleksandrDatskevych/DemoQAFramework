using NUnit.Framework;
using DemoQA.PageObjects.Elements;

namespace DemoQA.Tests.Elements
{
    [TestFixture]
    public class UploadDownloadTests : BaseTest
    {
        private readonly UploadDownloadPage Page = new();
        private readonly string DownloadsDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads\\");

        [OneTimeSetUp]
        public void Init()
        {
            Page.NavigateToCategory("Elements");
            Page.ExpandCategory("Elements");
            Page.NavigateToSubcategory("Upload and Download");
        }

        [Test]
        public void Download()
        {
            var fileName = "sampleFile.jpeg";
            var fileFullPath = DownloadsDirectory + fileName;

            try
            {
                Page.ClickDownloadButton();
                SpinWait.SpinUntil(() => File.Exists(fileFullPath), TimeSpan.FromSeconds(5));
                Assert.True(File.Exists(fileFullPath));
            }
            finally
            {
                File.Delete(fileFullPath);
            }
        }

        [Test]
        public void Upload()
        {
            var fileName = "pic.png";
            var fileFullPath = DownloadsDirectory + fileName;
            Page.UploadFile(fileFullPath);
            Assert.AreEqual($"C:\\fakepath\\{fileName}",Page.UploadedFilePath());
        }
    }
}
