using OpenQA.Selenium;
using DemoQA.Common.WebElements;

namespace DemoQA.PageObjects.Interactions
{
    public class ResizablePage : InteractionsPage
    {
        private MyWebElement _resizableBoxWithRestricton = new(By.Id("resizableBoxWithRestriction"));
        private MyWebElement _resizableBox = new(By.Id("resizable"));
        private MyWebElement _resizableHandleWithRestriction = new(By.XPath("//span[contains(@class, 'resizable-handle') " +
            "and ./parent::*[@id='resizableBoxWithRestriction']]"));
        private MyWebElement _resizableHandle = new(By.XPath("//span[contains(@class, 'resizable-handle') and ./parent::*[@id='resizable']]"));

        public bool InitialState() => _resizableBox.IsDisplayed() && _resizableBoxWithRestricton.IsDisplayed();

        public void ResizeBoxWithRestriction(int width, int height)
        {
            var widthToDrag = width - _resizableBoxWithRestricton.Size.Width;
            var heightToDrag = height - _resizableBoxWithRestricton.Size.Height;
            _resizableHandleWithRestriction.DragAndDropToOffset(widthToDrag, heightToDrag);
        }

        public void ResizeBox(int width, int height)
        {
            var widthToDrag = width - _resizableBox.Size.Width;
            var heightToDrag = height - _resizableBox.Size.Height;
            _resizableHandle.DragAndDropToOffset(widthToDrag, heightToDrag);
        }

        public System.Drawing.Size GetSizeOfRestrictedBox() => _resizableBoxWithRestricton.Size;

        public System.Drawing.Size GetSizeOfBox() => _resizableBox.Size;
    }
}
