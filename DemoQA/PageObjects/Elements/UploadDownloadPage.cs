using DemoQA.Common.WebElements;
using OpenQA.Selenium;

namespace DemoQA.PageObjects.Elements
{
    public class UploadDownloadPage : ElementsPage
    {
        private MyWebElement _downloadButton = new(By.Id("downloadButton"));
        private MyWebElement _uploadButton = new(By.Id("uploadFile"));
        private MyWebElement _uploadFilePath = new(By.Id("uploadedFilePath"));

        public void ClickDownloadButton() => _downloadButton.Click();

        public void UploadFile(string fileName) => _uploadButton.SendKeys(fileName);

        public string UploadedFilePath() => _uploadFilePath.Text;
    }
}
