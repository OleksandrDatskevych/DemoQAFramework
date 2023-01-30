using OpenQA.Selenium;
using DemoQA.Common.WebElements;

namespace DemoQA.PageObjects.Interactions
{
    public class DroppablePage : InteractionsPage
    {
        private MyWebElement _simpleTab = new(By.Id("droppableExample-tab-simple"));
        private MyWebElement _acceptTab = new(By.Id("droppableExample-tab-accept"));
        private MyWebElement _preventPropagationTab = new(By.Id("droppableExample-tab-preventPropogation"));
        private MyWebElement _revertDraggableTab = new(By.Id("droppableExample-tab-revertable"));
        private MyWebElement _draggableBox = new(By.Id("draggable"));
        private MyWebElement _droppableSimpleBox = new(By.XPath("(//*[@id='droppable'])[1]"));
        private MyWebElement _droppableAcceptBox = new(By.XPath("(//*[@id='droppable'])[2]"));
        private MyWebElement _draggableBoxPreventProp = new(By.Id("dragBox"));
        private MyWebElement _innerNotGreedyDroppable = new(By.Id("notGreedyInnerDropBox"));
        private MyWebElement _outerNotGreedyDroppable = new(By.Id("notGreedyDropBox"));
        private MyWebElement _innerGreedyDroppable = new(By.Id("greedyDropBoxInner"));
        private MyWebElement _outerGreedyDroppable = new(By.Id("greedyDropBox"));
        private MyWebElement _droppableSimpleText = new(By.XPath("(//*[@id='droppable']/p)[1]"));
        private MyWebElement _droppableAcceptText = new(By.XPath("(//*[@id='droppable']/p)[2]"));
        private MyWebElement _outerNotGreedyText = new(By.XPath("//*[@id='notGreedyDropBox']/p"));
        private MyWebElement _innerNotGreedyText = new(By.XPath("//*[@id='notGreedyInnerDropBox']/p"));
        private MyWebElement _outerGreedyText = new(By.XPath("//*[@id='greedyDropBox']/p"));
        private MyWebElement _acceptableBox = new(By.Id("acceptable"));
        private MyWebElement _notAcceptableBox = new(By.Id("notAcceptable"));

        public bool SimpleTabInitialState()
        {
            var result = _simpleTab.IsDisplayed() &&
                _acceptTab.IsDisplayed() &&
                _preventPropagationTab.IsDisplayed() &&
                _revertDraggableTab.IsDisplayed() &&
                _draggableBox.IsDisplayed() &&
                _droppableSimpleBox.IsDisplayed() &&
                _simpleTab.GetAttribute("aria-selected") == "true";

            return result;
        }

        public bool AcceptTabInitialState()
        {
            var result = _acceptableBox.IsDisplayed() &&
                _notAcceptableBox.IsDisplayed() &&
                _droppableAcceptBox.IsDisplayed();

            return result;
        }


        public bool PreventPropagationInitialState()
        {
            var result = _draggableBoxPreventProp.IsDisplayed() &&
                _innerGreedyDroppable.IsDisplayed() &&
                _innerNotGreedyDroppable.IsDisplayed();

            return result;
        }

        public void SwitchToSimpleTab() => _simpleTab.Click();

        public void SwitchToAcceptTab() => _acceptTab.Click();

        public void SwitchToPreventPropagationTab() => _preventPropagationTab.Click();

        public void DragAndDropDraggable() => _draggableBox.DragAndDropToElement(_droppableSimpleBox);

        public void DragAndDropNotAcceptable() => _notAcceptableBox.DragAndDropToElement(_droppableAcceptBox);

        public void DragAcceptable() => _acceptableBox.DragToElement(_droppableAcceptBox);

        public void DragDraggableToOuterNotGreedy() => _draggableBoxPreventProp.DragToElement(_outerNotGreedyText);

        public void DragDraggableToInnerNotGreedy() => _draggableBoxPreventProp.DragToElement(_innerNotGreedyDroppable);

        public void DragAndDropDraggableToOuterGreedy() => _draggableBoxPreventProp.DragAndDropToElement(_outerGreedyText);

        public void ReleaseAcceptable() => _acceptableBox.ReleaseElement();

        public void ReleaseDraggablePreventProp() => _draggableBoxPreventProp.ReleaseElement();

        public string GetTextOfSimpleDroppable() => _droppableSimpleText.Text;

        public string GetTextOfAcceptDroppable() => _droppableAcceptText.Text;

        public string GetTextOfOuterNotGreedy() => _outerNotGreedyText.Text;

        public string GetTextOfInnerNotGreedy() => _innerNotGreedyText.Text;

        public string GetTextOfOuterGreedy() => _outerGreedyText.Text;

        public string GetColorOfAcceptDroppable() => _droppableAcceptBox.GetCssValue("background-color");

        public string GetColorOfOuterNotGreedy() => _outerNotGreedyDroppable.GetCssValue("background-color");

        public string GetColorOfInnerNotGreedy() => _innerNotGreedyDroppable.GetCssValue("background-color");

        public bool IsInnerDroppableGreedyDisplayed() => _innerGreedyDroppable.IsDisplayed();
    }
}
